function validate(control) {
  var text = "";
  text = (control).value;
  if (text == "") {
    $(control).addClass('btn-warning');
  } else {
    $(control).removeClass('btn-light');
    $(control).removeClass('btn-warning');
  }
}
function focusfunction(control) {
  $(control).removeClass('btn-light');
  $(control).removeClass('btn-warning');
}
function callme() {
  $('[type="text"]').attr('onblur', 'validate(this)');
  $('[type="text"]').attr('onfocus', 'focusfunction(this)');
}
$('[type="text"]').attr('onblur', 'validate(this)');
$('[type="text"]').attr('onfocus', 'focusfunction(this)');
