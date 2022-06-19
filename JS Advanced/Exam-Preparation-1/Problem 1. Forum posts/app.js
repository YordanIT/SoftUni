window.addEventListener("load", solve)

function solve() {
  const publishBtn = document.getElementById('publish-btn');
  publishBtn.addEventListener('click', publish);
  const clearBtn = document.getElementById('clear-btn');
  clearBtn.addEventListener('click', clear);
  const ulReview = document.getElementById('review-list');
  const ulPublished = document.getElementById('published-list');

  const titleEl = document.getElementById('post-title');
  const categoryEl = document.getElementById('post-category');
  const contentEl = document.getElementById('post-content');

  const li = document.createElement('li');
  li.setAttribute('class', 'rpost');

  const editBtn = document.createElement('button');
  editBtn.setAttribute('class', 'action-btn-edit');
  editBtn.textContent = 'Edit';
  editBtn.addEventListener('click', edit);
  const approveBtn = document.createElement('button');
  approveBtn.addEventListener('click', approve);
  approveBtn.setAttribute('class', 'action-btn-approve');
  approveBtn.textContent = 'Approve';

  function publish() {
    if (titleEl.value === '' || categoryEl.value === '' || contentEl.value === '') {
      return
    }

    const article = document.createElement('article');
    const h4 = document.createElement('h4');
    h4.textContent = titleEl.value;
    titleEl.value = '';
    const p1 = document.createElement('p');
    p1.textContent = `Category: ${categoryEl.value}`;
    categoryEl.value = '';
    const p2 = document.createElement('p');
    p2.textContent = `Content: ${contentEl.value}`;
    contentEl.value = '';

    article.appendChild(h4)
    article.appendChild(p1)
    article.appendChild(p2)

    li.appendChild(article)
    li.appendChild(editBtn)
    li.appendChild(approveBtn)
    ulReview.appendChild(li)
  }

  function edit() {
    const items = li.children[0];
    titleEl.value = items.children[0].textContent;
    categoryEl.value = items.children[1].textContent.replace('Category: ', '');
    contentEl.value = items.children[2].textContent.replace('Content: ', '');
    li.remove()
  }

  function approve() {
    li.removeChild(editBtn);
    li.removeChild(approveBtn);
    ulPublished.appendChild(li);
  }

  function clear() {
    ulPublished.innerHTML = '';
  }
}

