(function(){
    "use strict";
    const $ = document.querySelector.bind(document);
    const $$ = document.querySelectorAll.bind(document);
    function activeService(){
        const servicesList = $('.services-list ')
        const services = $$('.services-list a') 
        const items = $$('.services-item')
        const select = $('#pay-field')
        servicesList.addEventListener('click', (e)=>{
          if(e.target != servicesList){
            services.forEach(service => {
              if(service!= e.target){
                service.classList.remove('active')
              }else
                service.classList.add('active')
            
              
            }) 
          }
         
          for (let index = 0; index < services.length; index++) {
            if(e.target != servicesList){
              const element = items[index];
              if(services[index] == e.target){
                element.classList.remove('d-none')
              }else element.classList.add('d-none')
            }
          }
        })
  
    }
    window.addEventListener('load', activeService);
  
})();