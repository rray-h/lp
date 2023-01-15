let modal = document.querySelector('.user__modal');
let btnList = document.querySelectorAll('.user__btn');
let close = document.querySelectorAll('.user__button');
let del = document.querySelectorAll('.delete');


for(let i = 0; i < btnList.length; i++) {
    if(btnList[i].querySelector = '.user__btn') {
        btnList[i].addEventListener('click', function(){
            modal.classList.add('block')
        })          
    }
}

for(let i = 0; i < close.length; i++) {
    if(close[i].querySelector = '.user__button') {
        close[i].addEventListener('click', function(){
            modal.classList.remove('block')
        })
    }
}
