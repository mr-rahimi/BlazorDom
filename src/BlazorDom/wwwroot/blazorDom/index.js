function domElement(element) {
    let _element = element;
    return {
        find: function (selector) {
            return domElement(_element.querySelector(selector));
        },
        findAll: function (selector) {
            return domElementList(_element.querySelectorAll(selector));
        },
        addEventListener: function (dotnetHelper, options) {
            const eventName = options.eventName;
            const handler = function () {
                dotnetHelper.invokeMethodAsync('InvokeHandler', null);
            }

            if (!_element)
                throw "element not found";

            _element.addEventListener(eventName, handler);

            return eventhandler(_element, eventName, handler);
        }
    };
}
function domElementList(elements) {
    let _elements = elements;
    return {
        find: function (selector) {
            //search in element collection
            return domElement(_elements.querySelector(selector));
        },
        findAll: function (selector) {
            //search in element collection

            return domElementList(_elements.querySelectorAll(selector));
        },
        addEventListener: function (dotnetHelper, options) {
            //register events on element collection
            const eventName = options.eventName;
            const handler = function () {
                dotnetHelper.invokeMethodAsync('InvokeHandler', null);
            }

            if (!_elements)
                throw "element not found";

            _elements.forEach(function (elem) {
                elem.addEventListener(eventName, handler);
            });

            return eventhandler(_elements, eventName, handler);
        },
        count: function () {
            //register events on element collection
            return _elements.length;
        }
    };
}
function eventhandler(elements, eventName, handler) {
    let matches = elements;
    return {
        removeHandler: function () {
            matches.forEach(function (elem) {
                elem.removeEventListener(eventName, handler);
            });
        }
    };
}

export function blazorDom() {
    return {
        find: function (selector) {
            const elm = document.querySelector(selector);

            if (!elm)
                throw "element not found";

            return domElement(elm);
        },
        findAll: function (selector) {
            const elm = document.querySelectorAll(selector);

            if (!elm)
                throw "element not found";

            return domElementList(elm);
        },
        addEventListener: function (dotnetHelper, options) {
            const matches = document.querySelectorAll(options.selector);
            const eventName = options.eventName;
            const handler = function () {
                dotnetHelper.invokeMethodAsync('InvokeHandler', null);
            }

            if (matches.length == 0)
                throw "element not found";

            matches.forEach(function (elem) {
                elem.addEventListener(eventName, handler);
            });

            return eventhandler(matches, eventName, handler);
        }
    }
}