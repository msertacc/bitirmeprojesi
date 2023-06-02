from asyncio.subprocess import PIPE
from distutils.command.config import config
from importlib.util import resolve_name
from posixpath import split
import os
import wave
from dataclasses import dataclass, asdict
import pyaudio
from a import Split
import pickle
import numpy as np
from scipy.io.wavfile import read
from sklearn.mixture import GaussianMixture
from featureextraction import extract_features
import warnings
warnings.filterwarnings("ignore")
from subprocess import run,PIPE
from flask import Flask, jsonify

app = Flask(__name__)

@app.route('/test/<user>', methods=['GET'])
def test(user):
    print(user)
    name = user +'.wav'

    s = Split()
    @dataclass
    class StreamParams:
        format: int = pyaudio.paInt16
        channels: int = 2
        rate: int = 44100
        frames_per_buffer: int = 1024
        input: bool = True
        output: bool = False

        def to_dict(self) -> dict:
            return asdict(self)
    
    class Recorder:
        """Recorder uses the blocking I/O facility from pyaudio to record sound
        from mic.
        Attributes:
            - stream_params: StreamParams object with values for pyaudio Stream
                object
        """
        def __init__(self, stream_params: StreamParams) -> None:
            self.stream_params = stream_params
            self._pyaudio = None
            self._stream = None
            self._wav_file = None

        def record(self, duration: int, save_path: str) -> None:
            """Record sound from mic for a given amount of seconds.
            :param duration: Number of seconds we want to record for
            :param save_path: Where to store recording
            """
            print("Start recording...")
            self._create_recording_resources(save_path)
            self._write_wav_file_reading_from_stream(duration)
            self._close_recording_resources()
            print("Stop recording")

        def _create_recording_resources(self, save_path: str) -> None:
            # print("saveme")
            self._pyaudio = pyaudio.PyAudio()
            self._stream = self._pyaudio.open(**self.stream_params.to_dict())
            self._create_wav_file(save_path)

        def _create_wav_file(self, save_path: str):
            # print("saveout")
            self._wav_file = wave.open(save_path, "wb")
            self._wav_file.setnchannels(self.stream_params.channels)
            self._wav_file.setsampwidth(self._pyaudio.get_sample_size(self.stream_params.format))
            self._wav_file.setframerate(self.stream_params.rate)

        def _write_wav_file_reading_from_stream(self, duration: int) -> None:
            # print("saveit")
            for _ in range(int(self.stream_params.rate * duration / self.stream_params.frames_per_buffer)):
                audio_data = self._stream.read(self.stream_params.frames_per_buffer)
                self._wav_file.writeframes(audio_data)

        def _close_recording_resources(self) -> None:
            self._wav_file.close()
            self._stream.close()
            self._pyaudio.terminate()

    stream_params = StreamParams()
    recorder = Recorder(stream_params)
    recorder.record(20, "full_voice/"+ name)
    # print("RECORD DONE")

    #Split audio
    # print('SPLIT START')
    s.process_audio("full_voice/"+name) 
    # print('SPLIT DONE')

    #path to training data
    source   = "voice_samples/"
    #path where training speakers will be saved
    dest = "models/"
    # Extracting features for each speaker (5 files per speakers

    features = np.asarray(())

    for i, (dir_path, dir_name, file_name) in enumerate(os.walk(source)):

        # ensure that we are not at root level
        if dir_path is not source:
            # save the semantic label (user1, user2....)
            user = dir_path.split("/")[-1]

            print("\nProcessing {}".format(user))

            # process file for a specific user
            for file in file_name:
                # load the audio file
                file_path = os.path.join(dir_path, file)  # join the full path for loading file
                sr, audio = read(file_path)

                print("{}".format(file_path))

                # extract 40 dimensional MFCC & delta MFCC features
                vector = extract_features(audio, sr)

                if features.size == 0:
                    features = vector
                else:
                    features = np.vstack((features, vector))

            gmm = GaussianMixture(n_components=16, max_iter=200, covariance_type='diag', n_init=3)
            gmm.fit(features)

            # dumping the trained gaussian model
            picklefile = user + ".gmm"
            pickle.dump(gmm, open(dest + picklefile, 'wb'))
            print('Model trained for :', picklefile, " with features = ", features.shape)
            features = np.asarray(())
        
    return jsonify({'response': 'Kayıt başarılı', 'isSuccess' : True})

@app.route('/control/<user>', methods=['GET'])
def result(user):  
    name = user
    #Live recording for testing
    @dataclass
    class StreamParams:
        format: int = pyaudio.paInt16
        channels: int = 2
        rate: int = 44100
        frames_per_buffer: int = 1024
        input: bool = True
        output: bool = False

        def to_dict(self) -> dict:
            return asdict(self)


    class Recorder:
        """Recorder uses the blocking I/O facility from pyaudio to record sound
        from mic.
        Attributes:
            - stream_params: StreamParams object with values for pyaudio Stream
                object
        """
        def __init__(self, stream_params: StreamParams) -> None:
            self.stream_params = stream_params
            self._pyaudio = None
            self._stream = None
            self._wav_file = None

        def record(self, duration: int, save_path: str) -> None:
            """Record sound from mic for a given amount of seconds.
            :param duration: Number of seconds we want to record for
            :param save_path: Where to store recording
            """
            print("Recording started...")
            self._create_recording_resources(save_path)
            self._write_wav_file_reading_from_stream(duration)
            self._close_recording_resources()
            print("Recording Ended")

        def _create_recording_resources(self, save_path: str) -> None:
            # print("saveme")
            self._pyaudio = pyaudio.PyAudio()
            self._stream = self._pyaudio.open(**self.stream_params.to_dict())
            self._create_wav_file(save_path)

        def _create_wav_file(self, save_path: str):
            # print("saveout")
            self._wav_file = wave.open(save_path, "wb")
            self._wav_file.setnchannels(self.stream_params.channels)
            self._wav_file.setsampwidth(self._pyaudio.get_sample_size(self.stream_params.format))
            self._wav_file.setframerate(self.stream_params.rate)

        def _write_wav_file_reading_from_stream(self, duration: int) -> None:
            # print("saveit")
            for _ in range(int(self.stream_params.rate * duration / self.stream_params.frames_per_buffer)):
                audio_data = self._stream.read(self.stream_params.frames_per_buffer)
                self._wav_file.writeframes(audio_data)

        def _close_recording_resources(self) -> None:
            self._wav_file.close()
            self._stream.close()
            self._pyaudio.terminate()

    stream_params = StreamParams()
    recorder = Recorder(stream_params)
    recorder.record(20, "identify/test.wav")
    # print("done")
    # path to training data
    source = "identify/"

    # path where training speakers will be saved
    modelpath = "models/"

    gmm_files = [os.path.join(modelpath, fname) for fname in
                 os.listdir(modelpath) if fname.endswith('.gmm')]

    # Load the Gaussian  Models
    models = [pickle.load(open(fname, 'rb')) for fname in gmm_files]
    speakers = [fname.split("/")[-1].split(".gmm")[0] for fname
                in gmm_files]
    
    path = source+"test.wav"

    sr, audio = read(path)
    vector = extract_features(audio, sr)

    log_likelihood = np.zeros(len(models))
    # print(log_likelihood)


    for x in range(len(models)):
        gmmall = models[x]  # checking with each model one by one
        scores = np.array(gmmall.score(vector))
        log_likelihood[x] = scores.sum()
    # print("LOG -> ",log_likelihood)
    w = np.argmax(log_likelihood)
    #result = log_likelihood[w]
    # print("result-index ", w)
    # print("r : ", result)
    a = ""
    if speakers[w] == name :
        a, isSuccess = "Tespit edildi " + name, True
    else :
        a, isSuccess = "Kullanıcı bulunamadi", False
    # if result > -25.0 or result == -(log_likelihood[result]):
    #     # print(result)
    #     # print(w)
    #     detected = speakers[w]
    #     # print(detected)
    
    #     if(name == speakers[w]):
    #         print("\tdetected as - ", speakers[w])
        
    #     else:
    #         print("Unknown User")
    # else:
    #     print("Unknown User ")
    
    # return redirect(request, 'index')
    return jsonify({'message': a, 'isSuccess' : isSuccess})


if __name__ == '__main__':
    app.run()