function solve(people,typeOfTheGroup,dayOfTheWeek){
    let price,result,discount;
    
    if(typeOfTheGroup=='Students') {
        if(dayOfTheWeek=='Friday'){
             price=8.45;
            if(people>=30){
                result=people*price;
                discount=0.15*result;
                result=result-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                 result = price * people;
                 console.log('Total price: ' + result.toFixed(2));
            }
            
        } else if(dayOfTheWeek=='Saturday'){
             price=9.80;
            if(people>=30){
                result=people*price;
                discount=0.15*result;
                result=result-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                 result = price * people;
                 console.log('Total price: ' + result.toFixed(2));
            }
        } else if(dayOfTheWeek=='Sunday'){
             price=10.46;
            if(people>=30){
                result=people*price;
                discount=0.15*result;
                result=result-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                 result = price * people;
                 console.log('Total price: ' + result.toFixed(2));
            }
        }
    } else if(typeOfTheGroup=='Business'){
        if(dayOfTheWeek=='Friday'){
            price=10.90;
            if(people>=100){
                discount=10*price;
                result=(people*price)-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        } else if(dayOfTheWeek=='Saturday'){
            price=15.60;
            if(people>=100){
                discount=10*price;
                result=(people*price)-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        } else if(dayOfTheWeek=='Sunday'){
            price=16.00;
            if(people>=100){
                discount=10*price;
                result=(people*price)-discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        }
    } else if(typeOfTheGroup=='Regular'){
        if(dayOfTheWeek=='Friday'){
            price=15.00;
            discount=0.5;
            if(people>=10 && people<=20){
                result=(people*price) * discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        } else if(dayOfTheWeek=='Saturday'){
            price=20.00;
            discount=0.5;
            if(people>=10 && people<=20){
                result=(people*price) * discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        } else if(dayOfTheWeek=='Sunday'){
            price=22.50;
            discount=0.5;
            if(people>=10 && people<=20){
                result=(people*price) * discount;
                console.log('Total price: ' + result.toFixed(2));
            } else {
                result=people*price;
                console.log('Total price: ' + result.toFixed(2));
            }
        }
    }
}
solve(30,"Students","Sunday");