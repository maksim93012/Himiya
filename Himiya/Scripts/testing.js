"use strict";
window.onload = function () {
    let questIcon = $("#questIcon");
    let questText = $("#questText");
    let questCounter = $("#questCounter");
    let inpt = $("#inpt");
    let test;
    let timer;
    let dataRes;

    GetDataTest(urlData, initAndRun);

    function initAndRun(data) {
            test = new Test(data);
            timer = new Timer(test.duration);
            dataRes = {
                User: localStorage.user,
                Test: localStorage.name,
                Group: localStorage.group
            };
        timer.onTick = function () {
            UpdateClock();
        }
        timer.onStop = function (dur) {
            if (dur <= 0) {
                StopAllTimeouts();
                    test.finished = true;
                    dataRes.Grade = Math.floor(test.rating);
                SendResult(urlWriteRes, dataRes);
                    storageClear();
                    let finMessage = ("Час вийшов. Ваша оцінка: " + Math.floor(test.rating)) + (Math.floor(test.rating) < 1 ? ".<br>Спробуйте ще раз" : "");
                    Show(finMessage, TypeOfIcon.Finished);
                }
        }

        $("#nameOfTest").text(test.Name);
        questCounter.text(test.numOfCurrent + " з " + test.length);
        UpdateClock();
        $("figure").css("min-height", (questIcon.innerHeight() + 10) + "px");
        Show(test.getQuestion(), TypeOfIcon.Question);
        var btnBlock = false;
        $("#enterBtn").click(function () {
            var timeout = 1000;
            if (!test.finished && !btnBlock) {
                btnBlock = true;
                if (test.checkAnswer(inpt.html())) {
                    Show("Вірно!", TypeOfIcon.Right);
                } else {
                    Show("Неправильно! Правильна відповідь: " + test.rightAnswer, TypeOfIcon.Wrong);
                    timeout = 2000;
                }
                if (!test.finished) {
                    setTimeout(function () {
                        Show(test.getQuestion(), TypeOfIcon.Question);
                        questCounter.text(test.numOfCurrent + " з " + test.length);
                        localStorage.numOfCurrent = test.numOfCurrent;
                        btnBlock = false;
                    }, timeout);
                } else {
                    dataRes.Grade = Math.floor(test.rating);

                    SendResult(urlWriteRes, dataRes);
                    storageClear();
                    setTimeout(function () {
                        test.duration = 0;
                        test.finished = true;
                        questCounter.text("");
                        UpdateClock();
                        timer.Stop();
                        let finMessage = ("Тест завершено. Ваша оцінка: " + Math.floor(test.rating)) + (Math.floor(test.rating) < 1 ? ".<br>Спробуйте ще раз" : "");
                        Show(finMessage, TypeOfIcon.Finished);
                    }, timeout);
                }
                ClearInput();
            }
        });
        timer.Start();
    }

    function UpdateClock() {
        let mins = Math.floor(timer.duration / 60);
        let secs = timer.duration % 60;
        $("#time").text((mins > 9 ? mins : "0" + mins) + ":" + (secs > 9 ? secs : "0" + secs));
    }

    function Show(text, typeicon) {
        questIcon.hide();
        questIcon.attr("src", "/Content/" + typeicon + "Icon.svg").show(300);
        questText.css("left", "110%").html(text).animate({ left: "0%" }, 400);
    }

    function ClearInput() {
        inpt.empty();
        inpt.attr("data-empty", "true");
        inpt.append("<span id='placeHolder'>Дайте відповідь</span>");
    }
};