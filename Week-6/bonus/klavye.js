var values = ["asli", "menekşe", "çöz", "giresun"];
control(values);

function control(values) {
  var size = values.length;
  for (let i = 0; i < size; i++) {
    var value = values[i];

    valueControl(value);
  }
}

function valueControl(value) {
  var arrayOne = ["q", "w", "e", "r", "t", "y", "u", "ı", "o", "p", "ğ", "ü"];
  var arrayTwo = ["a", "s", "d", "f", "g", "h", "j", "k", "l", "ş", "i"];
  var arrayThree = ["z", "x", "c", "v", "b", "n", "m", "ö", "ç"];
  var valueSize = value.length;
  for (let j = 0; j < valueSize; j++) {
    var searchChar = value.charAt(j);
    console.log(arrayControl(arrayOne, searchChar, value));
    console.log("////////////////////////////////////////");
    console.log(arrayControl(arrayTwo, searchChar, value));
    console.log("////////////////////////////////////////");
    console.log(arrayControl(arrayThree, searchChar, value));
  }
}

function arrayControl(array, searchChar, value) {
  var newStr = "";
  var newList = [];
  for (let x = 0; x < array.length; x++) {
    if (searchChar == array[x]) {
      newStr = newStr + searchChar;
      var isim = newStr;
      var a = isim.indexOf(value);
      if (a == 0) {
        console.log(value);
      }
    }
  }
  return newList;
}
