function signCheck(numOne,numTwo,numThree){
    let sum=numOne*numTwo*numThree;
    if(sum>=0){
        return 'Positive';
    }
    else{
        return 'Negative';
    }
}