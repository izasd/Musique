function boleto(){
    window.document.getElementById('pagcartao').style.display = 'none'
    window.document.getElementById('pagpix').style.display = 'none'
    window.document.getElementById('pagboleto').style.display = 'block'
}

function pix(){
    window.document.getElementById('pagcartao').style.display = 'none'
    window.document.getElementById('pagpix').style.display = 'block'
    window.document.getElementById('pagboleto').style.display = 'none'
}

function cartao(){
    window.document.getElementById('pagcartao').style.display = 'block'
    window.document.getElementById('pagpix').style.display = 'none'
    window.document.getElementById('pagboleto').style.display = 'none'
}