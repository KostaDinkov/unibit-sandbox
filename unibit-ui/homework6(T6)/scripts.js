const nodes = document.querySelectorAll('.node');
console.log(nodes);
let selected;
let result;

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

