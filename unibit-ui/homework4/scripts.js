const cars = [
  {
    make: "Suzuki",
    models: ["Vitara", "Jimny", "S-Cross", "Swift"]
  },
  {
    make: "Toyota",
    models: ["Land Cruiser", "Hilux", "Corolla", "Rav4", "Prius"]
  },
  {
    make: "Volkswagen",
    models: ["Golf", "Passat", "Tiguan", "Arteon", "Touareg"]
  }
]
const database = [];
const addBtn = document.getElementById("addBtn");
const engineSelect = document.getElementById("engineType");
const colorInput = document.getElementById("color");
const dateInput = document.getElementById("date");
const options = document.querySelectorAll(".option input");
const infoInput = document.getElementById("info");

//populate select elements
const makeSelect = document.getElementById("make");


cars.forEach((object) => {
  const option = document.createElement("option");
  option.value = object.make;
  option.textContent = object.make;
  makeSelect.appendChild(option);
})

//when a car make selection is made, update the car model dropdown
const modelSelect = document.getElementById("model");
makeSelect.onchange = (e) => {
  const models = cars.filter((item) => item.make === e.target.value)[0].models;

  //remove options from previous car makes
  while (modelSelect.firstChild) modelSelect.removeChild(modelSelect.firstChild);

  models.forEach((model) => {
    const option = document.createElement("option");
    option.value = model;
    option.textContent = model;
    modelSelect.appendChild(option);
  })
}

const Car = {
  make: "",
  model: "",
  engineType: "",
  color: "",
  registered: "",
  options: [],
  info: ""
}

addBtn.addEventListener('click',onSubmit ,false);

function onSubmit(evt){
  evt.preventDefault();
  let car = Object.create(Car);
  car.make = makeSelect.value;
  car.model = modelSelect.value;
  car.engineType = engineSelect.value;
  car.color = colorInput.value;
  car.registered = dateInput.value;
  car.info = infoInput.value;
  options.forEach((option)=>{
    if(option.checked){
      car.options.concat(option.name);
    }

  });

  console.log(car);

}

function addCar(car){

}



