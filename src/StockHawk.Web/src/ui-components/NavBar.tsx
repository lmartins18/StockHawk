import { useCallback, useContext, useRef, useState } from "react";
import { NavLink, useNavigate } from "react-router-dom";
import ThemeContext from "../contexts/ThemeContext/ThemeContext";
import { BsFillMoonStarsFill, BsFillSunFill } from "react-icons/bs";
import { RiMenu4Line } from "react-icons/ri";
import SignInSignOutButton from './SignInSignOutButton';
import { useIsAuthenticated } from "@azure/msal-react";

export default function NavBar() {
    const navigate = useNavigate();
    const [toggleNav, setToggleNav] = useState<boolean>(false);
    const darkTheme = useRef<boolean>();
    const toggleClass = toggleNav ? "block" : "hidden";
    const { currentTheme, changeCurrentTheme } = useContext(ThemeContext);
    const changeToggle = useCallback(() => {
        setToggleNav(!toggleNav);
    }, [toggleNav]);

    const isAuthenticated = useIsAuthenticated();

    function changeTheme() {
        changeCurrentTheme(currentTheme === "light" ? "dark" : "light");
        darkTheme.current = !darkTheme.current;
        localStorage.setItem("theme", darkTheme.current ? "dark" : "light");
    }

    // // Detect change storage
    // window.addEventListener("storage", (e) => { });
    // useEffect(() => {
    //     // Dark mode
    //     darkTheme.current = localStorage.getItem("theme") === "dark";
    //     changeCurrentTheme(darkTheme.current ? "dark" : "light");
    //     // Fechar NavMenu quando utilizador clicka fora da nav.
    //     document.addEventListener("click", (e) => {
    //         if (toggleNav) {
    //             const target = e.target;
    //             const navMenu = document.getElementById("navmenu")!;
    //             if (navMenu && !navMenu.contains(target as Node)) {
    //                 changeToggle();
    //             }
    //         }
    //     });
    // }, [toggleNav]);

    return (
        <header
            id="navmenu"
            className={"sticky top-0 !z-[1000] shadow-sm shadow-slate-600"}
        >
            <nav className="bg-slate-900 border-gray-200 px-2 sm:px-4 py-2.5 rounded-b">
                <div className="container-fluid flex flex-wrap items-center">
                    <div id="nav-menu-button-container" className="flex flex-end"></div>
                    <span
                        id="nav-title"
                        onClick={() => {
                            navigate("/");
                            setToggleNav(false);
                        }}
                    >
                        DKM
                    </span>
                    <div id="nav-menu-button-container" className="flex flex-end">
                        <button
                            id="theme-toggle"
                            title="toggle-dark-mode-button"
                            type="button"
                            className="text-gray-500 hover:text-orange-400 focus:outline-none rounded-lg text-sm p-2.5 mr-1"
                            onClick={changeTheme}
                        >
                            {darkTheme.current ? (
                                <BsFillMoonStarsFill
                                    id="theme-toggle-light-icon"
                                    className={"w-5 h-5"}
                                />
                            ) : (
                                <BsFillSunFill
                                    id="theme-toggle-dark-icon"
                                    className="w-5 h-5"
                                />
                            )}
                        </button>
                        <SignInSignOutButton />
                        <button
                            type="button"
                            className="inline-flex items-center p-2 ml-3 text-sm rounded-lg md:hidden hover:bg-slate-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:hover:bg-slate-800 dark:focus:ring-gray-600 hover:!text-slate-500"
                            onClick={changeToggle}
                        >
                            <span className="sr-only">Open main menu</span>
                            <RiMenu4Line className="text-2xl sm:text-3xl text-orange-400" />
                        </button>
                    </div>
                    <div
                        className={toggleClass + " w-full md:block md:w-auto"}
                        id="navbar-default"
                    >
                        <ul className="flex flex-col p-4 mt-4 border rounded-lg md:flex-row md:space-x-8 md:mt-0 md:text-sm md:font-medium md:border-0 bg-slate-800 md:bg-slate-900 border-slate-700 !text-white dark:hover:!text-sky-400">
                            <li className="text-white">
                                <NavLink to="/">
                                    Home
                                </NavLink>
                            </li>
                            {isAuthenticated ? (
                                <>
                                    <li>Logged in links here</li>
                                </>
                            ) : (
                                <li>
                                    unauthenticated links here
                                </li>
                            )}
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    );
}