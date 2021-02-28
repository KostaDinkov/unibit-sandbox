const userForm = document.getElementById('userForm');

const inputs = document.querySelectorAll('input');
inputs.forEach(i => i.addEventListener('keyup', (e) => {
  if (e.key === "Enter") {
    userForm.reportValidity()
  }

}));

document.getElementById('submitBtn').addEventListener('click', (evt) => {
  evt.preventDefault();
  let isValid = userForm.checkValidity();
  userForm.reportValidity();

  if (isValid) {
    displayPerson();
  }
  else {
    displayError();
  }
  document.getElementById('textBtn').addEventListener('click', (evt) => {
    evt.target.parentNode.style.display = 'none';
  })
})

function displayPerson() {

  const info = setUpInfoBox()

  const selectInput = document.getElementById('country');
  let html = `
        <h2>Успешно добавен потребител</h2>
        <p>
          ${inputs[0].value}<br>
          ${inputs[1].value}<br>
          ${inputs[2].value}, ${selectInput.value} <br>
          Потребителско име: ${inputs[3].value}<br>
          Имейл: ${inputs[4].value}<br>
          Оценка по UI: ${inputs[5].value}<br>
        </p>
        <span id='textBtn'>Затвори</span>
  `
  info.style.backgroundColor = "darkseagreen";

  info.innerHTML = html;
  userForm.reset();
}

function displayError() {
  const info = setUpInfoBox();
  info.style.display = "block"
  let html = `
        <h2>Некоректни данни</h2>
        <p>
          Моля попълнете формата както следва:
          <ul>
            <li>Име - букви и интервал, между 5 и 30 символа.</li>
            <li>Адрес - между 10 и 30 символа.</li>
            <li>Пощенски код - 4 цифрен код.</li>
            <li>Потребителско име - букви, цифри и специални символи ! # $ % ^ & *.</li>
            <li>Имейл - валиден имейл адрес</li>
            <li>Оценка по UI - 6</li>
          </ul>
        </p>
        <span id='textBtn'>Затвори</span>
  `
  info.style.backgroundColor = "rgb(197, 75, 75)"
  info.innerHTML = html;
}

function setUpInfoBox() {

  const formCoords = userForm.getBoundingClientRect();
  const info = document.getElementById('info');

  info.style.top = formCoords.top + "px";
  info.style.left = (formCoords.right + 30) + "px";
  info.style.display = "block";

  return info;
}