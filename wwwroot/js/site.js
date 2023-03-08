"use strict"
// vars

// end vars

//Funtion
function _navmenu (Element){

}
const url_nav = () =>
{
    const Element = ( element )=>{
        return document.querySelector(element);
    } 
    const contif = (element, name)=>{
        const Element2 = element.split('/')[3].toLowerCase();
        if(  Element2 == name.toLowerCase() || Element2 == name.toLowerCase() + '#' ){
            const active =  Element("#"+name.toLowerCase());
            const show = Element("#"+name.toLowerCase()+"-collapse");
            show.classList.add("show");
            active.classList.add("active");
        } 
        if(Element2 == "" || Element2 == "#" ){
            const active =  Element("#school");
            const show = Element("#school-collapse");
            show.classList.add("show");
            active.classList.add("active");
        }
        const subname = document.querySelector("#"+name);
        const show = document.querySelector('#'+name+'-collapse');

        subname.addEventListener("click", async()=>
        {
            const show2 = document.querySelector('.show');
            const showBoolean =  subname.nextElementSibling.classList.contains('show');
            if( showBoolean == false ){
                show.classList.add('show');
                await show2 == null ? 
                    show.classList.add('show')
                    : 
                    subname.id == show2.id.split('-')[0] 
                        ? show.classList.add('show') 
                            : show2.classList.remove('show') ;
            } else{
                show.classList.remove('show');
            }
        });
    }
    var url =  window.location.href;
    //[].forEach(item => );
    contif(url, 'school');
    contif(url, 'evaluaciones');
    contif(url, 'alumno');
    contif(url, 'aula');
    contif(url, 'ticher');
    contif(url, 'asignatura');
    contif(url, 'admin');
}

url_nav();
//End Funtion
