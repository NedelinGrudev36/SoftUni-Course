function simpleCalculator(num1,num2,opeartor){
    if(opeartor==='multiply'){
        return num1 * num2;
    }

    if(opeartor==='devide'){
        return num1 / num2;
    }

    if(opeartor === 'add'){
        return num1 + num2;
    }

    if(opeartor === 'subtract'){
        return num1 - num2;
    }
}

simpleCalculator(5,5,'multiply');