"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/examHub").build();
var endTime = new Date();

//await connection.start();
function getExam(id) {
	connection.start().then(function () {
		//myAlert("Sınav", "Sınavınız sona erdi. Ana ekrana yönlendiriliyorsunuz..", "error", 1666);
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
	var text = "";
	endTime = new Date(exams[0].endDate.toString());
	//text = text.slice(0, text.indexOf("."));

	//text = text.slice(0, text.indexOf("T")) + ' ' + text.slice(text.indexOf("T") + 1, text.length);

	//$('#timeRemain').attr({ startDate: exams[0].startDate, endDate: text });

	BindExamsToGrid(exams);
})

function BindExamsToGrid(exams) {
	$("#tblExam tbody").empty();
	var tr;
	$.each(exams, function (index, exam) {
		tr = $('<tr/>');
		tr.append(`<td>${exam.id}</td>`);
		tr.append(`<td>${exam.examId}</td>`);
		tr.append(`<td>${exam.studentId}</td>`);
		$('#tblExam').append(tr);
	});

}
