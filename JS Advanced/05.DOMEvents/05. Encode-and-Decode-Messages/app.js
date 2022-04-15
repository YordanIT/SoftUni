function encodeAndDecodeMessages() {
    document.getElementById('main').addEventListener('click', (e) => {
       
        if (e.target.tagName !== 'BUTTON') {
            return;
        }
 
        let decodedText = document.getElementsByTagName('textarea')[0];
        let encodedText = document.getElementsByTagName('textarea')[1];
 
        if (e.target.textContent.includes('Encode')) {
            
            let message = decodedText.value;
            let encoded = [];
            for (let i = 0; i < message.length; i++) {
                let currSymbol = message.charCodeAt(i);
                encoded.push(String.fromCharCode(currSymbol + 1));
            }
            decodedText.value = '';
            encodedText.value = encoded.join('');
        } else if (e.target.textContent.includes('Decode')) {
            
            let message = encodedText.value;
            let decoded = [];
            
            for (let i = 0; i < message.length; i++) {
                let currSymbol = message.charCodeAt(i);
                decoded.push(String.fromCharCode(currSymbol - 1));
            }
            encodedText.value = decoded.join('');
        }
    });
}
