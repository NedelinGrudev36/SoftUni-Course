function solve(text, word){
    let result=text.split(' ').filter(element=>element===word).length;
    console.log(result);
}