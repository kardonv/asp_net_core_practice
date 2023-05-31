const languages = {
    '0': 'en',
    '1': 'uk'
};

const languagesMap = {
    'en': '0',
    'uk': '1',
};

window.addEventListener('load', () => {
    const languageSelector = document.querySelector('#language');

    if (!languageSelector) return;

    const cookies = parseCookies();

    if (cookies.lang) {
        const [culture] = cookies.lang.split('|');
        const [_, language] = culture.split('=');

        languageSelector.childNodes.forEach((item) => {
            if (item.nodeType === 1 && item.value === languagesMap[language]) {
                item.selected = true;
            }
        });
    }

    languageSelector.addEventListener('change', (event) => {
        const selectedLanguage = languages[event.target.value];

        if (!selectedLanguage) return;

        // lang=c=uk|uic=uk
        document.cookie = `lang=c=${selectedLanguage}|uic=${selectedLanguage}`;

        location.reload();

    });    
});

function parseCookies() {
    const cookies = {};

    const pairs = document.cookie.split(';');

    for (const cookie of pairs) {
        const index = cookie.indexOf('=');

        const cookieName = cookie.substring(0, index).trim();
        const cookieValue = cookie.substring(index + 1).trim();

        cookies[cookieName] = cookieValue;
    }

    return cookies;
}