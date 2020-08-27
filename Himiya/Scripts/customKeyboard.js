function ToggleCaseAll(){
	var shk = $('#shiftKey1, #shiftKey2');
	if(shk.attr('data-pressed')!="true")
	{
		$('.keyboard .upperable').css("text-transform", "uppercase");
		shk.attr({"data-pressed": "true"});
	}else{
		$('.keyboard .upperable').css("text-transform", "lowercase");
		shk.attr({"data-pressed": "false"});
	}
}

function UkrLangOn(){
	$('#eng_layout').css('display', 'none');
	$('#ukr_layout').css('display', 'table');
}

function EngLangOn(){
	$('#ukr_layout').css('display', 'none');
	$('#eng_layout').css('display', 'table');
}

function SubToggle(){
	var sk = $('#subKey1, #subKey2');
	if(sk.attr("data-pressed") == "true"){
		sk.attr("data-pressed", "false");
	}else{
		sk.attr("data-pressed", "true");
	}
}

var Inpt = $('#inpt');
function KeyStrokeHandler(sender){
	if(Inpt.attr('data-empty')=="true"){
		Inpt.empty();
		Inpt.attr('data-empty', 'false')
	}
	var txtLength = Inpt.text().length;
	if(txtLength < 30){
	var innerText = $(sender).text();
	if($('#shiftKey1').attr('data-pressed') == "true"){
		innerText = innerText.toUpperCase();
		ToggleCaseAll();}
	if($('#subKey1').attr('data-pressed') == "true"){
		innerText = '<sub>'+innerText+'</sub>';
		SubToggle();}
	Inpt.append(innerText);
	}
}

function BackSpace(){
	if(Inpt.attr("data-empty")=="true")return;
	var txt = Inpt.html();
	if(txt.endsWith("&nbsp;")){
		txt = txt.substring(0, txt.lastIndexOf("&nbsp;"));
	}
	else {
		if(txt.endsWith("</sub>")){
		txt = txt.substring(0, txt.lastIndexOf("<sub>"));
		}
		else{
		txt = txt.substring(0, txt.length-1);
		}
	}
	if(txt == ""){
		Inpt.empty();
		Inpt.attr("data-empty", "true");
		Inpt.append("<span id='placeHolder'>Дайте відповідь</span>");
	}
	else{
		Inpt.empty();
		Inpt.append(txt);
	}
}

function Space(){
	Inpt.append("&nbsp;");
}