function validate(obj) {
    const methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    const uriRegex = /[\W\w\d]+/;
    const versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    const messageRegex = /^([^<>\&'"]*)$/;

    const header = {
        method: obj.method,
        uri: obj.uri,
        version: obj.version,
        message: obj.message
    }

    if (header.method === undefined || header.uri === undefined
        || header.version === undefined || header.message === undefined) {
        throw new Error('Invalid request header: missing property')
    } else if (!methods.some(x => x === header.method)) {
        throw new Error('Invalid request header: Invalid Method')
    } else if (!header.uri.match(uriRegex)) {
        throw new Error('Invalid request header: Invalid URI')
    } else if (!versions.some(x => x === header.version)) {
        throw new Error('Invalid request header: Invalid Version')
    } else if (!header.message.match(messageRegex)) {
        throw new Error('Invalid request header: Invalid URI')
    }

    return header
}

console.log(validate({
    method: 'POST',
    version: 'HTTP/2.0',
    message: 'rm -rf /*'
}
))