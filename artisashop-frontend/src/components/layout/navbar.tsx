import { ReactComponent as PersonIcon } from '../../assets/icons/bs/person.svg';
import { ReactComponent as CartIcon } from '../../assets/icons/bs/cart.svg';
import { ReactComponent as ChatLeftIcon } from '../../assets/icons/bs/chat-left.svg';

export default function Navbar() {
    return (
        <header className="sticky top-0 z-50 h-12 flex px-16 items-center justify-between bg-richblack shadow-md">
            <a href="#" className="select-none hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                <div className="text-xl">
                    Dashboard
                </div>
            </a>

            {/* Find a better thing to put here */}
            {/* <a href="#" className="select-none hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                <div className="text-xl">
                    Les artisans
                </div>
            </a>
            <a href="#" className="select-none hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                <div className="text-xl">
                    Les créations
                </div>
            </a> */}

            <a href="/" className="absolute inset-x-0 mx-auto w-14">
                <img className="w-14 h-16 mt-5 rounded-full shadow-xl" src="/img/LogoOval.png" alt="Logo Artisashop" />
            </a>

            <div className="flex gap-8">
                <a href="#" className="text-light hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                    <ChatLeftIcon className="h-7 w-7" />
                </a>
                <a href="#" className="text-light hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                    <CartIcon className="h-7 w-7 -mt-0.5" />
                </a>
                <a href="#" className="text-light hover:text-secondary active:text-saddlebrown transition-colors duration-200">
                    <PersonIcon className="h-7 w-7" />
                </a>
            </div>
            {/* <div className="flex gap-3 text-light hover:text-secondary transition-colors duration-200">
                <PersonIcon className="h-7 w-7" />
                <div className="text-xl">Se connecter</div>
            </div> */}
        </header>
    )
}