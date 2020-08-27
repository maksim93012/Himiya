"use strict";

function Test(data) {
    this.name = data.name;
    this.questions = data.questions;
    this.numOfCurrent = data.numOfCurrent;
    this.length = data.questions.length;
    this.finished = false;
    this.duration = data.duration;
    this.priceOfAnswer = data.priceOfAnswer;
    this.rating = 0;
    this.onFinish = (rating) => { };
    this.rightAnswer = "";

    this.getQuestion = function () {
        return this.questions[this.numOfCurrent - 1].question;
    };

    this.checkAnswer = function (answer) {
        if (this.finished) return null;
        let res;
        if (this.questions[this.numOfCurrent - 1].ignoreCase) {
            res = (answer.toLowerCase() === this.questions[this.numOfCurrent - 1].answer.toLowerCase());
        } else {
            res = (answer === this.questions[this.numOfCurrent - 1].answer);
        }
        if (res) {
            this.rating += this.priceOfAnswer;
        } else {
            this.rightAnswer = this.questions[this.numOfCurrent - 1].answer;
        }
        if (this.numOfCurrent >= this.questions.length) {
            this.finished = true;
            this.rating = Math.floor(this.rating);
            this.onFinish(this.rating);
        } else {
            this.numOfCurrent++;
        }
        return res;
    }
}


function Timer(duration) {
    this.stopped = true;
    this.duration = duration;
    this.delay = 1000;
    this._timeoutID = null;
    this.onTick = (duration) =>{ };
    this.onStop = (duration) => { };

    this.Tick = function () {
        if (--this.duration <= 0) {
            this.Stop();
            return;
        }
        let context = this;
        this._timeoutID = setTimeout(() => { this.Tick.call(context) }, this.delay);
        if (this.onTick) this.onTick.call(this, this.duration);
    };

    this.Start = function () {
        this.stopped = false;
        this.Tick();
    };

    this.Stop = function () {
        this.stopped = true;
        clearTimeout(this._timeoutID);
        if (this.onStop) this.onStop(this.duration);
    };
}


function GetDataTest(url, callBack) {
    if (localStorage.name && Math.floor((new Date() - Date.parse(localStorage.time)) / 1000) < Number.parseInt(localStorage.duration)) {
        let duration = Math.floor((new Date() - Date.parse(localStorage.time)) / 1000);
        let data = {};
        data.duration = localStorage.duration - duration;
        data.name = localStorage.name;
        data.numOfCurrent = +localStorage.numOfCurrent;
        data.priceOfAnswer = +localStorage.priceOfAnswer;
        data.questions = JSON.parse(localStorage.questions);
        if (callBack) callBack(data);
    } else {
        $.get(url, (data) => {
            data = JSON.parse(data);
            localStorage.name = data.name;
            localStorage.time = new Date().toString();
            localStorage.numOfCurrent = data.numOfCurrent = 1;
            localStorage.duration = data.duration;
            localStorage.priceOfAnswer = data.priceOfAnswer;
            localStorage.questions = JSON.stringify(data.questions);
            if (callBack) callBack(data);
        });
    }
}


function storageClear() {
    let u = localStorage.user;
    localStorage.clear();
    localStorage.user = u;
}


function SendResult(url, data) {
    $.ajax({
        type: 'POST',
        url: url,
        data: data
    });
}


let TypeOfIcon = {
    Question: "quest",
    Right: "right",
    Wrong: "wrong",
    Finished: "finish"
};

function StopAllTimeouts() {
    let id = setTimeout(() => { }, 1000);
    while (id--) clearTimeout(id);
}
