const nodes = document.querySelectorAll('.node');
console.log(nodes);
let selected;
let resultElement;
let resultNodes;

nodes.forEach(n => {
  n.addEventListener('click', (e) => {
    setSelected(e.target);
    e.stopPropagation();

  }, true)
})

function setSelected(elm) {

  selected && (selected.style.backgroundColor = "");
  selected = elm;

  selected.style.backgroundColor = 'red';
  console.log(selected);
}
const resultBox = document.getElementById('resultBox');
const infoBox = document.getElementById('infoBox');

document.getElementById('parentNodeBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.parentNode;
    resultElement.style.backgroundColor = "#f27c8d";
    resultBox.textContent = `Parent node is ${resultElement.nodeName} with class '${resultElement.className}'`;

  })


document.getElementById('childNodesBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultNodes = selected.childNodes;
    if(resultNodes.length ===0){
      resultBox.textContent = `No child nodes.`;
      return;
    }
    resultNodes.forEach(n => n.style && (n.style.backgroundColor = "#f27c8d"));
    resultBox.textContent = `Child nodes are: ${resultNodes}`;

  })

document.getElementById('firstChildBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.firstChild;
    if (!resultElement) {
      resultBox.textContent = "No first child node";
      return;
    }

    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `First child node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('firstElementChildBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.firstElementChild;
    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `First child node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })



function clearResults() {
  if (resultElement && resultElement.nodeType === Node.ELEMENT_NODE) resultElement.style.backgroundColor = "";
  if (resultNodes) resultNodes.forEach(n => { if (n.nodeType === Node.ELEMENT_NODE) n.style.backgroundColor = "" });
};

