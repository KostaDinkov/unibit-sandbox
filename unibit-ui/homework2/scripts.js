
// Използвам масив от имена на изображения
const photos = ["1.jpg","2.jpg","3.jpg", "4.jpg","5.jpg"];
const baseImgPath = "img/";

// задаваме началното изображение да е нулевият индекс от масива
// като променяме src атрибута на img елемента в html файла.
const imgElement = document.getElementById("imgHolder");
imgElement.src = baseImgPath + photos[0];

const nav = document.querySelector(".navigation");

// за всеки елемент от масива създаваме span елемент,
// който стилизираме (в styless.css) да изглежда като сиво кръгче
// на което задаваме onclik хендлъра да изпълнява функция, която сменя
// текущото изображение, към което соки img елемента
for (let i = 0; i < photos.length; i++) {
  const circle = createDotNav(photos[i],imgElement);
  // по подразбиране, първият елемент ще бъде с клас active
  if(i==0)circle.setAttribute("class","active");
  
  nav.appendChild(circle);
}

function createDotNav(url, imgElement){
  const circle = document.createElement("span");

  circle.onclick = (event)=>{
    imgElement.src = baseImgPath + url;
    const circles = document.querySelectorAll(".navigation span");
    //премахваме "active" класа от другите кръгчета
    circles.forEach(e=>{e.setAttribute("class","")})
    
    //задаваме "active" клас на кръгчето, което сме "кликнали"
    event.target.setAttribute("class","active");
  }
  return circle;
}