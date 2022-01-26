var value = "nurhayat";
console.log(turnItOverOneMethod(value));
console.log(turnItOverTwoMethod(value));
console.log(turnItOverThreeMethod(value));
console.log(turnItOverFourMethod(value));

function turnItOverOneMethod(value) {
  let size = value.length;
  var newList = [size];
  let j = 0;
  for (let i = size; i >= 0; i--) {
    var newValue = value.charAt(i);
    newList[j] = newValue;
    j++;
  }
  var value2 = newList.toString();
  return value2;
}

function turnItOverTwoMethod(value) {
  var splitString = value.split("");
  var reverseArray = splitString.reverse();
  var joinArray = reverseArray.join("");
  return joinArray;
}

function turnItOverThreeMethod(value) {
  if (value === "") return "";
  else return turnItOverThreeMethod(value.substr(1)) + value.charAt(0);
}

function turnItOverFourMethod(value) {
  var newString = "";
  for (var i = value.length - 1; i >= 0; i--) {
    newString += value[i];
  }
  return newString;
}
//Daha kısa bir kod ve string metodları kullanıldığı için üçüncü çözüm
