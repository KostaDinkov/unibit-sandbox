const paragraphs =
  ["'The greatest glory in living lies not in never falling, but in rising every time we fall'. -Nelson Mandela",
    "'The way to get started is to quit talking and begin doing.'-Walt Disney",
    "'Your time is limited, so don't waste it living someone else's life. Don't be trapped by dogma – which is living with the results of other people's thinking.' -Steve Jobs",
    "'If life were predictable it would cease to be life, and be without flavor.' -Eleanor Roosevelt",
    "'Life is what happens when you're busy making other plans.' -John Lennon"
  ]

/**
 * Creates paragraphs from array of strings and adds them to a target element
 * @param {Array<String>} paragraphs an array of strings 
 * @param {String} selector the query selector for the constainer element for the paragraphs
 */
function createParagraphs(selector, paragraphs) {

  let quotesContainer = document.querySelector(selector)
  for (let i = 0; i < paragraphs.length; i++) {
    let paragraph = document.createElement("p");
    paragraph.textContent = paragraphs[i];

    quotesContainer.appendChild(paragraph);
  }
}
/**
 * Generates H3 tags for every paragraph in section with class quotes
 * @param {String} selector The query selector for the container element for the H3 tags 
 */
function generateH3s(selector) {
  const headers = document.querySelectorAll(selector);
  const paragraphs = document.querySelectorAll("section.quotes p")

  for (let i = 0; i < paragraphs.length; i++) {
    headers[i].textContent = paragraphs[i].textContent;
  }

}
/**
 * Sets random color to a list of html elements
 * @param {NodeListOf<Element>} elements a list of html elements 
 */
function setRandomColor(elements) {
  const randomColor = Math.floor(Math.random() * 16777215).toString(16);
  for (let i = 0; i < elements.length; i++) {
    elements[i].style.color = `#${randomColor}`;
  }
}

createParagraphs(".quotes", paragraphs);

//Create a button that will call the generateH3s function
const generateH3Button = document.createElement("button");
generateH3Button.textContent = "Generate H3 tags"
generateH3Button.onclick = () => {
  generateH3s("section.headings h3");
  document.getElementById("colorButton").style.display = "block";

};
const quotesSection = document.querySelector(".quotes");
quotesSection.appendChild(generateH3Button);


//Create a button that will change the color of the H3 tags
const colorButton = document.createElement("button");
colorButton.textContent = "Set Random Color To H3 headings"
colorButton.id = "colorButton";
colorButton.onclick = () => setRandomColor(document.querySelectorAll("section.headings h3"));
colorButton.style.display = "none";
document.getElementById("buttonContainer").appendChild(colorButton);




