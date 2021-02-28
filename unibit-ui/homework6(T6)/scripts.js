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
    if (resultNodes.length === 0) {
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
    if (!resultElement) {
      resultBox.textContent = `No first element node.`;
      return;
    }
    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `First child node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('lastChildBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.lastChild;
    if (!resultElement) {
      resultBox.textContent = "No last child node";
      return;
    }

    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `Last child node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('nextSiblingBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.nextSibling;
    if (!resultElement) {
      resultBox.textContent = "No next sibling node";
      return;
    }

    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `Next sibling node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('nextElementSiblingBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.nextElementSibling;
    if (!resultElement) {
      resultBox.textContent = `No next element sibling node.`;
      return;
    }
    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `Next element sibling node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('previousSiblingBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.previousSibling;
    if (!resultElement) {
      resultBox.textContent = "No previous sibling node";
      return;
    }

    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `Previous sibling node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('previousElementSiblingBtn')
  .addEventListener('click', (e) => {
    clearResults();
    resultElement = selected.previousElementSibling;
    if (!resultElement) {
      resultBox.textContent = `No previous element sibling node.`;
      return;
    }
    if (resultElement.nodeType === Node.ELEMENT_NODE) {
      resultElement.style.backgroundColor = "#f27c8d";
    }
    resultBox.textContent = `Previous element sibling node is ${resultElement.nodeName} with class '${resultElement.className}'`;
  })

document.getElementById('createElementBtn')
  .addEventListener('click', (e) => {
    clearResults();

    const circle = document.createElement('div');
    circle.classList.add('circle');
    if (!selected) {
      resultBox.textContent = "Please select an element first."
      return;
    }
    selected.appendChild(circle);

    resultBox.textContent = `Created element ${circle.nodeName} with class '${circle.className}'`;
  })

document.getElementById('insertBeforeBtn')
  .addEventListener('click', (e) => {
    clearResults();

    const circle = document.createElement('div');
    circle.classList.add('circle');
    if (!selected) {
      resultBox.textContent = "Please select an element first."
      return;
    }
    selected.parentNode.insertBefore(circle, selected);

    resultBox.textContent = `Inserted element ${circle.nodeName} with class '${circle.className}' before '${selected.nodeName}'`;
  })

document.getElementById('removeChildBtn')
  .addEventListener('click', (e) => {
    clearResults();

    if (!selected) {
      resultBox.textContent = "Please select an element first."
      return;
    }
    const parent = selected.parentNode;
    parent.removeChild(selected);

    resultBox.textContent = `Removing ${selected.nodeName} with class '${selected.className}' from '${parent.nodeName}' with class '${parent.className}'`;
  })

document.getElementById('replaceChildBtn')
  .addEventListener('click', (e) => {
    clearResults();

    const circle = document.createElement('div');
    circle.classList.add('circle');
    if (!selected) {
      resultBox.textContent = "Please select an element first."
      return;
    }
    selected.parentNode.replaceChild(circle, selected);

    resultBox.textContent = `Replaced element ${selected.nodeName} with class '${selected.className}' with '${circle.nodeName} - ${circle.className}'`;
  })

function clearResults() {
  if (resultElement && resultElement.nodeType === Node.ELEMENT_NODE) resultElement.style.backgroundColor = "";
  if (resultNodes) resultNodes.forEach(n => { if (n.nodeType === Node.ELEMENT_NODE) n.style.backgroundColor = "" });
};


const infos = {
  parentNode: "The Node.parentNode read-only property returns the parent of the specified node in the DOM tree.",
  childNodes: "The Node.childNodes read-only property returns a live NodeList of child nodes of the given element where the first child node is assigned index 0. Child nodes include elements, text and comments.",
  firstChild: "The Node.firstChild read-only property returns the node's first child in the tree, or null if the node has no children. If the node is a Document, it returns the first node in the list of its direct children.",
  firstElementChild: "The ParentNode.firstElementChild read-only property returns the object's first child Element, or null if there are no child elements.",
  lastChild: "The Node.lastChild read-only property returns the last child of the node. If its parent is an element, then the child is generally an element node, a text node, or a comment node. It returns null if there are no child elements.",
  nextSibling: "The Node.nextSibling read-only property returns the node immediately following the specified one in their parent's childNodes, or returns null if the specified node is the last child in the parent element.",
  nextElementSibling: "The Element.nextElementSibling read-only property returns the element immediately following the specified one in its parent's children list, or null if the specified element is the last one in the list.",
  previousSibling: "The Node.previousSibling read-only property returns the node immediately preceding the specified one in its parent's childNodes list, or null if the specified node is the first in that list.",
  previousElementSibling: "The Element.previousElementSibling read-only property returns the Element immediately prior to the specified one in its parent's children list, or null if the specified element is the first one in the list.",
  createElement: "In an HTML document, the document.createElement() method creates the HTML element specified by tagName, or an HTMLUnknownElement if tagName isn't recognized.",
  insertBefore: `The Node.insertBefore() method inserts a node before a reference node as a child of a specified parent node.
  If the given node already exists in the document, insertBefore() moves it from its current position to the new position. (That is, it will automatically be removed from its existing parent before appending it to the specified new parent.)
  This means that a node cannot be in two locations of the document simultaneously.`,
  removeChild: "The Node.removeChild() method removes a child node from the DOM and returns the removed node.",
  replaceChild: "The Node.replaceChild() method replaces a child node within the given (parent) node."
}

const buttons = document.querySelectorAll('.controls button');

buttons.forEach(b => b.addEventListener('click', (evt) => {
  let infoKey = evt.target.id.replace('Btn', "");
  infoBox.textContent = infos[infoKey];
}))
