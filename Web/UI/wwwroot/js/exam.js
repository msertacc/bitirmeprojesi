"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/examHub").build();
var endTime = new Date();

//await connection.start();
function getExam(id) {
	connection.start().then(function () {
		InvokeExams(id);
	}).catch(function (err) {
		return console.error(err.toString());
	})
}

function InvokeExams(id) {
	connection.invoke("SendExams", id).catch(function (err) {
		return console.error(err.toString());
	})
}

connection.on("ReceivedExams", function (exams) {
	var isOk = exams[0].isEnded == 1 ? true : false;
	isOk == true ? myAlert("Sınav", "Sınavınız sona erdi. Ana ekrana yönlendiriliyorsunuz..", "error", 1666) : null; 
})
