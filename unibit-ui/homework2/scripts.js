const photos = ["1.jpg","2.jpg","3.jpg", "4.jpg","5.jpg"];
const baseImgPath = "img/";

const imgElement = document.getElementById("imgHolder");
imgElement.src = baseImgPath + photos[0];


const nav = document.querySelector(".navigation");
for (let i = 0; i < photos.length; i++) {
  const circle = createDotNav(photos[i],imgElement);
  nav.appendChild(circle);
}

function createDotNav(url, imgElement){
  const circle = document.createElement("span");

  circle.onclick = (event)=>{
    imgElement.src = baseImgPath + url;
    const circles = document.querySelectorAll(".navigation span");

    //clear active class from rest of the circles
    circles.forEach(e=>{e.setAttribute("class","")})
    event.target.setAttribute("class","active");
  }

  return circle;

}