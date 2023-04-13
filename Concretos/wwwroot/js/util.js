/**
 * Establece el alto de un elemento con el restante del alto de la pantalla
 * @param {string} idElementTop Id del elemento de arriba
 * @param {string} idElementBottom Id del elemento de abajo (Se le establecerá el alto)
 * @param {int} adjustment Número que se resta al final para ajustal la medida
 */
function setRemainingHeight(idElementTop, idElementBottom, adjustment) {
    const topElement = $('#' + idElementTop);
    const bottomElement = $('#' + idElementBottom);
    const header = $('header'); 
    const footer = $('footer');
    const totalHeight = $(window).height();

    bottomElement.height(totalHeight - topElement.height() - header.height() - footer.height() - adjustment);
}