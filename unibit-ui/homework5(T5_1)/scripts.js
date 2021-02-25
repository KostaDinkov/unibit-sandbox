// string split

const strSplitInput = document.getElementById("strSplitInput");
const strSplitResult = document.getElementById('strSplitResult');

strSplitResult.textContent = `[${strSplitInput.value.split(",").map(x => "'" + x + "'").join(", ")}]`;
strSplitInput.onkeyup = (e) => {
  strSplitResult.textContent = `[${e.target.value.split(",").map(x => "'" + x + "'").join(", ")}]`;
}

// string replace all

const strReplaceAllInput1 = document.getElementById('strReplaceAllInput1');
const strReplaceAllInput2 = document.getElementById('strReplaceAllInput2');
const strReplaceAllInput3 = document.getElementById('strReplaceAllInput3');
const strReplaceAllResult = document.getElementById('strReplaceAllResult');
const strReplaceAllBtn = document.getElementById('strReplaceAllBtn');

strReplaceAllBtn.onclick = (e) => {
  let oldValue = strReplaceAllInput2.value;
  let newValue = strReplaceAllInput3.value;
  let result = strReplaceAllInput1.value.replaceAll(oldValue, newValue);
  strReplaceAllResult.textContent = result;
}

// string trim
const strTrimInput = document.getElementById('strTrimInput');
const strTrimResult = document.getElementById('strTrimResult');
const strTrimBtn = document.getElementById('strTrimBtn');

strTrimBtn.onclick = (e) => { strTrimResult.textContent = strTrimInput.value.trim(); }

// array filter

const arrFilterInput = document.getElementById('arrFilterInput');
const arrFilterResult = document.getElementById('arrFilterResult');
const arrFilterBtn = document.getElementById('arrFilterBtn');

arrFilterBtn.onclick = (e) => {
  arrFilterResult.textContent = arrFilterInput.value
    .replaceAll(/\[|\]/gm, "")
    .split(',')
    .filter(x => !Number.isNaN(Number(x)))
    .join(", ");
}

//array map
const arrMapInput = document.getElementById('arrMapInput');
const arrMapResult = document.getElementById('arrMapResult');
const arrMapBtn = document.getElementById('arrMapBtn');

arrMapBtn.onclick = (e) => {
  arrMapResult.textContent = arrMapInput.value
    .replaceAll(/\[|\]/gm, "")
    .split(",").map(x => x ** 2)
    .join(", ");
}

//array find
const arrFindInput = document.getElementById('arrFindInput');
const arrFindResult = document.getElementById('arrFindResult');
const arrFindBtn = document.getElementById('arrFindBtn');

arrFindBtn.onclick = (e) => {
  arrFindResult.textContent = arrFindInput.value
    .replaceAll(/\[|\]/gm, "")
    .split(",").find(x => x > 5);

}

//navigation
const sections = document.querySelectorAll("section.tutorial");
const links = document.querySelectorAll(".aside ul li");

for (let index = 0; index < links.length; index++) {
  sections.forEach(s => s.style.display = "none");
  sections[0].style.display = "block";
  links[index].onclick = (e) => {
    sections.forEach(s => s.style.display = "none");
    sections[index].style.display = "block";
  }

}

//resize inputs
const inputs = document.querySelectorAll('input');

inputs.forEach(input => {
  input.size = input.value.length+1;
  input.addEventListener("keyup", (e) => {
    input.size = input.value.length+1;
  });
});

