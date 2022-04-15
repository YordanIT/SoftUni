function solve() {
  let inputText = document.getElementById('input').value;
  let sentences = inputText.split('.').filter(x => x.length > 0).filter(Boolean).map(x => x + '.');
  let paragraphs = [];
  let i = 0;

  for (let index = 0; index < sentences.length; index++) {
    if (index === 0) {
      paragraphs[i] = sentences[index];
      continue;
    }else if (index % 3 === 0) {
      i++;
      paragraphs[i] = sentences[index];
      continue;
    }
    paragraphs[i] += sentences[index];
  }

  let output = document.getElementById('output');
  for (let index = 0; paragraphs < paragraphs.length; index++) {
    output.innerHTML += `<p>${paragraphs[index]}</p>`;    
  }
}