function solve(number){
    let firstNumber=number.shift();
    let lastNumber=number.pop();
    console.log(firstNumber + lastNumber);
}
solve(5,5);