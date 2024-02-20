function solve(start,end){
    let Sum;
    for(let i=start;i<=end;i++){
        Sum+=i;
        console.log(Sum);
    }
    console.log('Sum: ' + Sum);
}
solve(5,10);