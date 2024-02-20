function solve(first,second,third){
    if(first>second && first>third){
        console.log('The largest number is ' + first + '.');
    } else if(second>first && second>third) {
        console.log('The largest number is ' + second + '.');
    } else if(third>first && third>second){
        console.log('The largest number is ' + third + '.');
    }
}
solve(5, -3, 16);