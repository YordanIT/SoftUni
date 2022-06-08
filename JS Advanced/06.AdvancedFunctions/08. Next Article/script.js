function getArticleGenerator(articles) {
    let div = document.getElementById('content');

    function showNext() {
        if (articles.length == 0) {
            return
        }
        let article = document.createElement('article')
        article.textContent = articles.shift()
        div.appendChild(article)
    }

    return showNext
}
