import { CMyClass } from "./MyClass";

window.onload = (): void => {
    main();
};

function main() {
    const appBox: HTMLElement = document.getElementById("application_inner");
    const myClass: CMyClass = new CMyClass();
    appBox.innerText = myClass.getMessage();
}
