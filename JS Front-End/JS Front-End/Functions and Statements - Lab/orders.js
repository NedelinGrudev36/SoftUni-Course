function orders(product,quantity){
    let result=0;
    if(product==='coffee'){
        result=1.50 * quantity;
        return result.toFixed(2);
    }

    if(product === 'water'){
        result=1.00 * quantity;
        return result.toFixed(2);
    }

    if(product === 'coke'){
        result=1.40 * quantity;
        return result.toFixed(2);
    }

    if(product==='snack'){
        result=2.00 * quantity;
        return result.toFixed(2);
    }
}

orders("water", 5);