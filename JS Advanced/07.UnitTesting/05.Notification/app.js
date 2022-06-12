function notify(message) {
  const div = document.getElementById('notification');
  div.textContent = message

  if (div.style.display === 'none') {
    div.style.display = 'block'
  } else {
    div.style.display = 'none'
  }
}