var array1 = [2, 3, 4];
var array2 = [];
array1.forEach(function (element, index) {
  array2[index] = girlsPowerToplami(element);
});
console.log(array2);

function girlsPowerToplami(num) {
  num = num / 2 + 3;
  return num;
}
