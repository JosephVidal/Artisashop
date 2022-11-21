namespace Artisashop.Services.MailService;

using Artisashop.Models;
using Artisashop.Models.Enum;
using Helpers;

public struct MailTemplates
{
    private readonly static Utils _utils = new();

    public static string AccountCreated(string url)
    {
        return @"<html lang='en'>
        <head>
            <meta charset='utf-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <meta name='google' content='notranslate'>
            <meta name='author' content='Artisashop'>

            <title>Artisashop</title>

            <link href='https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.1.0/mdb.min.css' rel='stylesheet'>
            <style type='text/css' id='less:css-root'>
                :root {
                    --bs-dark: #141C26 !important;
                    --bs-light: #F4EBE1;
                    --bs-white: #F4EBE1;
                    --bs-primary: #5A202E;
                    --bs-secondary: #DC6D04;
                    --bs-tertiary: #79B8F6;
                }

                @font-face {
                    font-family: 'Blackford';
                    src: url('https://localhost:5001/font/MyBlackford-Regular.ttf');
                }

                .content {
                    height: inherit;
                }

                * {
                    font-family: 'Raleway-Black', sans-serif !important;
                }

                body,
                html {
                    height: 100%;
                    background: var(--bs-light);
                    color: var(--bs-dark);
                }

                .parallax {
                    background-attachment: fixed;
                    background-position: center;
                    background-repeat: no-repeat;
                    background-size: cover;
                }

                .bg-primary {
                    background-color: var(--bs-primary) !important;
                    color: var(--bs-light) !important;
                }

                    .bg-primary h1,
                    .bg-primary h2,
                    .bg-primary h3,
                    .bg-primary h4,
                    .bg-primary h5,
                    .bg-primary h6 {
                        color: var(--bs-light) !important;
                        font-family: Blackford serif !important;
                    }

                    .bg-primary figcaption {
                        color: var(--bs-light);
                    }

                    .bg-primary a {
                        color: var(--bs-light);
                    }

                        .bg-primary a:hover,
                        .bg-primary a figcaption:hover {
                            color: var(--bs-secondary);
                        }

                            .bg-primary a:hover figcaption,
                            .bg-primary a figcaption:hover figcaption {
                                color: var(--bs-secondary);
                            }

                a,
                *:hover,
                figcaption,
                *:after {
                    transition: 0.2s;
                }

                .bg-secondary {
                    background-color: var(--bs-secondary) !important;
                }

                .bg-tertiary {
                    background-color: var(--bs-tertiary) !important;
                }

                .bg-light {
                    background-color: var(--bs-light) !important;
                }

                    .bg-light .active {
                        color: var(--bs-dark) !important;
                        border-color: var(--bs-dark) !important;
                    }

                    .bg-light .nav-link:hover {
                        color: var(--bs-dark) !important;
                    }

                .navbar-dark {
                    background-color: var(--bs-dark) !important;
                }

                    .navbar-dark .active {
                        color: var(--bs-secondary) !important;
                        border-color: var(--bs-light);
                    }

                    .navbar-dark .nav-link {
                        color: var(--bs-light) !important;
                    }

                        .navbar-dark .nav-link:hover {
                            color: var(--bs-secondary) !important;
                        }

                .breadcrumb-item.active {
                    color: var(--bs-dark);
                }

                .content-font {
                    color: var(--bs-light);
                }

                .flip2 {
                    animation: flip2 1s cubic-bezier(0.23, 1, 0.32, 1.2);
                    margin-top: -53px;
                }

                .flip3 {
                    animation: flip3 1s cubic-bezier(0.23, 1, 0.32, 1.2);
                    margin-top: -5px;
                }

                .btn-outline-dark {
                    color: var(--bs-dark) !important;
                    border-color: var(--bs-dark) !important;
                }

                    .btn-outline-dark:hover {
                        color: var(--bs-secondary) !important;
                        border-color: var(--bs-secondary) !important;
                    }

                .btn-outline-light {
                    color: var(--bs-light) !important;
                    border-color: var(--bs-light) !important;
                }

                    .btn-outline-light:hover {
                        color: var(--bs-secondary) !important;
                        border-color: var(--bs-secondary) !important;
                    }

                .btn-primary {
                    background-color: var(--bs-primary);
                    color: var(--bs-light);
                }

                    .btn-primary:hover {
                        background-color: var(--bs-secondary);
                        color: var(--bs-light);
                    }

                .btn-secondary {
                    background-color: var(--bs-secondary);
                    color: var(--bs-light);
                }

                    .btn-secondary:hover {
                        background-color: var(--bs-primary);
                        color: var(--bs-light);
                    }

                .form-check-input {
                    background-color: var(--bs-light);
                }

                .form-control {
                    background-color: var(--bs-light);
                }

                    .form-control::placeholder {
                        color: var(--bs-dark);
                    }

                    .form-control:focus {
                        background-color: var(--bs-light);
                        color: var(--bs-dark);
                        border-color: var(--bs-light);
                        box-shadow: 0 0 0 0.25rem rgba(244, 235, 225, 0.25);
                    }

                @keyframes flip2 {
                    0% {
                        margin-top: -5px;
                    }

                    100% {
                        margin-top: -53px;
                    }
                }

                @keyframes flip3 {
                    0% {
                        margin-top: -53px;
                    }

                    100% {
                        margin-top: -5px;
                    }
                }

                @media (min-width: 1024px) {
                    #other .grid-sizer,
                    #other .grid-item {
                        width: 25%;
                    }
                }

                @media (max-width: 1024px) {
                    #other .grid-sizer,
                    #other .grid-item {
                        width: 33%;
                    }
                }

                @media (max-width: 720px) {
                    #other .grid-sizer,
                    #other .grid-item {
                        width: 50%;
                    }
                }

                @media (max-width: 400px) {
                    #other .grid-sizer,
                    #other .grid-item {
                        width: 100%;
                    }
                }

                #other .grid-item-w2 {
                    width: 50%;
                }

                #other .grid-item {
                    float: left;
                    padding: 5px;
                }

                .card {
                    border-radius: 30px;
                }

                    .card .top-img {
                        border-radius: 30px 30px 0 0;
                    }

                    .card h1,
                    .card h2,
                    .card h3,
                    .card h4,
                    .card h5,
                    .card h6 {
                        text-align: center;
                        font-family: Blackford, serif !important;
                    }

                    .card .nav-link {
                        background-color: var(--bs-light);
                        color: var(--bs-dark);
                    }

                        .card .nav-link.active.active {
                            background-color: var(--bs-primary);
                            color: var(--bs-light);
                        }

                        .card .nav-link:hover:not(.active) {
                            background-color: var(--bs-secondary);
                            color: var(--bs-light);
                        }

                .login-card {
                    border-radius: 30px;
                    margin-left: auto;
                    margin-right: auto;
                    margin-top: 5vh;
                    text-align: center;
                    color: var(--bs-light);
                    background-color: var(--bs-dark);
                }

                    .login-card h1 {
                        text-align: center;
                        font-family: Blackford, serif !important;
                        font-size: calc(1rem + 6vw);
                        color: var(--bs-light);
                        letter-spacing: 0.2rem;
                    }

                    .login-card h2 {
                        margin-bottom: 32px;
                    }

                    .login-card a {
                        color: var(--bs-tertiary);
                    }

                        .login-card a:hover {
                            color: var(--bs-secondary);
                        }

                .card.dark {
                    background-color: var(--bs-dark);
                    color: var(--bs-light);
                }

                    .card.dark label {
                        color: var(--bs-light);
                    }

                    .card.dark a:not(.nav-link) {
                        color: var(--bs-tertiary);
                    }

                        .card.dark a:not(.nav-link):hover {
                            color: var(--bs-secondary);
                        }

                .accordion-button:not(.collapsed) {
                    background-color: var(--bs-primary);
                    color: var(--bs-light) !important;
                }

                    .accordion-button:not(.collapsed):focus {
                        border-color: var(--bs-primary);
                    }

                .accordion-button:hover.collapsed {
                    background-color: var(--bs-secondary);
                    color: var(--bs-light);
                    border-color: var(--bs-secondary);
                    box-shadow: 0 4px 10px 0 rgba(0, 0, 0, 0.2), 0 4px 20px 0 rgba(0, 0, 0, 0.1);
                }

                .accordion-button:focus {
                    border-color: var(--bs-light);
                    box-shadow: none;
                }

                input[type=checkbox]:checked {
                    background: var(--bs-secondary) !important;
                    border-color: var(--bs-secondary) !important;
                }

                    input[type=checkbox]:checked:focus::before {
                        box-shadow: 0 0 0 13px var(--bs-secondary);
                    }

                .short-input {
                    width: 10vw;
                }

                .long-input {
                    width: 20vw;
                }

                .red-button {
                    border-radius: 30px;
                    background-color: var(--bs-primary);
                    color: var(--bs-light);
                    border: 0;
                    padding: 5px 30px 5px 30px;
                }

                    .red-button:hover {
                        background-color: var(--bs-secondary);
                    }

                .notify-badge {
                    position: absolute;
                    right: 26px;
                    top: 28px;
                    background: var(--bs-primary);
                    text-align: center;
                    border-radius: 30px 30px 30px 30px;
                    color: var(--bs-light);
                    padding: 3px 8px;
                    font-size: 9px;
                }

                #resultList a {
                    color: black;
                    text-decoration: none;
                }

                    #resultList a:hover {
                        color: #C8C8C8;
                        text-decoration: none;
                        transition: all 0.2s ease-out;
                    }

                .searchbar > div:first-of-type {
                    height: 39px;
                    background-color: var(--bs-light);
                    border-radius: 30px;
                    padding: 6px;
                }

                    .searchbar > div:first-of-type input {
                        color: var(--bs-dark);
                        border: 0;
                        outline: 0;
                        background: none;
                        caret-color: transparent;
                        padding: 0 7px;
                        line-height: 30px;
                        width: calc(10.5rem + 10vw);
                    }

                    .searchbar > div:first-of-type ::placeholder {
                        color: var(--bs-dark);
                    }

                    .searchbar > div:first-of-type label[for='searchBar'] {
                        display: inline-flex;
                    }

                        .searchbar > div:first-of-type label[for='searchBar'] > a,
                        .searchbar > div:first-of-type label[for='searchBar'] label {
                            color: var(--bs-dark);
                            height: 27px;
                            width: 27px;
                            float: right;
                            display: flex;
                            justify-content: center;
                            align-items: center;
                            border-radius: 50%;
                            text-decoration: none;
                        }

                            .searchbar > div:first-of-type label[for='searchBar'] > a:hover,
                            .searchbar > div:first-of-type label[for='searchBar'] label:hover {
                                color: var(--bs-light);
                                background: var(--bs-secondary);
                                transition: 0.2s;
                            }

                .searchbar .form-check {
                    white-space: nowrap;
                }

                    .searchbar .form-check input[type='checkbox'] {
                        background-color: var(--bs-light);
                        border-color: var(--bs-light);
                    }

                        .searchbar .form-check input[type='checkbox']:after {
                            background-color: var(--bs-light) !important;
                            border-color: var(--bs-light) !important;
                            transition: 0.1s;
                        }

                        .searchbar .form-check input[type='checkbox']:before {
                            box-shadow: 3px -1px 0 10px #fafafa !important;
                        }

                    .searchbar .form-check label {
                        overflow: hidden;
                        height: 1.4rem;
                        white-space: nowrap;
                    }

                        .searchbar .form-check label ul {
                            padding: 0;
                        }

                            .searchbar .form-check label ul li {
                                font-weight: 700;
                                margin-bottom: 16px;
                            }

                .searchbar.dark {
                    background-color: unset !important;
                }

                    .searchbar.dark > div:first-of-type {
                        height: 39px;
                        background-color: var(--bs-dark) !important;
                        border-radius: 30px;
                        padding: 6px;
                    }

                        .searchbar.dark > div:first-of-type input {
                            color: var(--bs-light);
                            border: 0;
                            outline: 0;
                            background: none;
                            caret-color: transparent;
                            padding: 0 7px;
                            line-height: 30px;
                            width: calc(9.5rem + 10vw);
                        }

                        .searchbar.dark > div:first-of-type ::placeholder {
                            color: var(--bs-light);
                        }

                        .searchbar.dark > div:first-of-type label[for='searchBar'] {
                            display: inline-flex;
                        }

                            .searchbar.dark > div:first-of-type label[for='searchBar'] a {
                                color: var(--bs-light);
                                height: 27px;
                                width: 27px;
                                float: right;
                                display: flex;
                                justify-content: center;
                                align-items: center;
                                border-radius: 50%;
                                text-decoration: none;
                            }

                        .searchbar.dark > div:first-of-type:hover > label[for='searchBar'] > a {
                            color: var(--bs-dark);
                            background: var(--bs-secondary);
                            transition: 0.2s;
                        }

                    .searchbar.dark .form-check input[type='checkbox'] {
                        background-color: var(--bs-dark);
                        border-color: var(--bs-dark);
                    }

                        .searchbar.dark .form-check input[type='checkbox']:after {
                            background-color: var(--bs-light) !important;
                            border-color: var(--bs-dark) !important;
                            transition: 0.1s;
                        }

                        .searchbar.dark .form-check input[type='checkbox']:before {
                            box-shadow: 3px -1px 0 10px #fafafa !important;
                        }

                    .searchbar.dark .form-check label {
                        overflow: hidden;
                        height: 1.4rem;
                        white-space: nowrap;
                    }

                        .searchbar.dark .form-check label ul {
                            padding: 0;
                        }

                            .searchbar.dark .form-check label ul li {
                                font-weight: 700;
                                margin-bottom: 16px;
                            }

                .modal-content {
                    background: var(--bs-light);
                }

                    .modal-content * {
                        color: var(--bs-dark);
                    }

                        .modal-content * > a {
                            color: var(--bs-tertiary);
                        }

                            .modal-content * > a:hover {
                                color: var(--bs-secondary);
                            }

                .card {
                    background-color: var(--bs-light);
                }

                .craftsman-title {
                    font-family: Blackford, serif !important;
                    font-size: 8rem;
                    color: black;
                    letter-spacing: 0.2rem;
                }

                @media (max-width: 320px) {
                    .craftsman-title {
                        font-size: 6rem;
                    }
                }

                @media (min-width: 768px) {
                    .h-md-50 {
                        height: 50%;
                    }
                }

                h4 {
                    font-weight: bold;
                    margin-bottom: 0;
                }

                .bs-docs-masthead {
                    position: relative;
                    padding: 80px 15px;
                    color: #CDBFE3;
                    text-align: center;
                    text-shadow: 0 1px 0 rgba(0, 0, 0, 0.1);
                    background-color: #7F4365;
                    background-image: -webkit-gradient(linear, left top, left bottom, from(#6D366E), to(#7F4365));
                    background-image: -webkit-linear-gradient(top, #6D366E 0, #7F4365 100%);
                    background-image: -o-linear-gradient(top, #6D366E 0, #7F4365 100%);
                    background-image: linear-gradient(to bottom, #6D366E 0, #7F4365 100%);
                    background-repeat: repeat-x;
                }

                .bs-doc-icon {
                    padding-top: 10px;
                    color: #FFFFFF;
                    font-size: 220px;
                }

                @media (max-width: 767px) {
                    .bs-doc-icon {
                        padding-top: 0;
                        font-size: 120px;
                        margin-bottom: 30px;
                    }
                }

                @media (max-width: 640px) {
                    .bs-doc-icon {
                        padding-top: 0;
                        margin-bottom: 0;
                        font-size: 0;
                        visibility: hidden;
                    }
                }

                .bs-doc-title {
                    width: 80%;
                    font-size: 80px;
                    line-height: 90px;
                    color: #FFFFFF;
                    margin: 0 auto 30px;
                }

                .bs-doc-leftAlign {
                    text-align: left;
                }

                .bs-doc-rightAlign {
                    text-align: right;
                }

                .bs-doc-subtitle {
                    width: 80%;
                    font-size: 30px;
                    color: #FFFFFF;
                    margin: 0 auto 30px;
                }

                .bs-doc-description {
                    width: 80%;
                    font-size: 20px;
                    color: #FFFFFF;
                    margin: 0 auto 30px;
                }

                .bs-doc-translation {
                    margin-top: 20px;
                }

                .carousel-inner {
                    width: 91%;
                }

                .carousel-control-next.dark,
                .carousel-control-prev.dark {
                    color: var(--bs-dark);
                    width: 3%;
                }

                .carousel-control-next,
                .carousel-control-prev {
                    color: var(--bs-light);
                    width: 3%;
                }

                @media (max-width: 767px) {
                    .carousel-inner .carousel-item > div {
                        display: none;
                    }

                        .carousel-inner .carousel-item > div:first-child {
                            display: block;
                        }
                }

                .carousel-inner .carousel-item.active,
                .carousel-inner .carousel-item-next,
                .carousel-inner .carousel-item-prev {
                    display: flex;
                }
                /* medium and up screens */
                @media (min-width: 768px) {
                    .carousel-inner .carousel-item-end.active,
                    .carousel-inner .carousel-item-next {
                        transform: translateX(33%);
                    }

                    .carousel-inner .carousel-item-start.active,
                    .carousel-inner .carousel-item-prev {
                        transform: translateX(-33%);
                    }
                }

                .carousel-inner .carousel-item-end,
                .carousel-inner .carousel-item-start {
                    transform: translateX(0);
                }

                #productCarousel .card.dark,
                #craftsmanCarousel .card.dark {
                    color: var(--bs-light);
                }

                    #productCarousel .card.dark:hover,
                    #craftsmanCarousel .card.dark:hover {
                        color: var(--bs-secondary);
                    }

                    #productCarousel .card.dark img,
                    #craftsmanCarousel .card.dark img {
                        max-height: 170px;
                    }

                #productCarousel .card,
                #craftsmanCarousel .card {
                    color: var(--bs-dark);
                }

                    #productCarousel .card:hover,
                    #craftsmanCarousel .card:hover {
                        color: var(--bs-secondary);
                    }

                * {
                    box-sizing: border-box;
                }

                body {
                    font-family: sans-serif;
                }
                /* ---- grid ---- */
                .grid {
                    height: 90% !important;
                }
                    /* clearfix */
                    .grid:after {
                        content: '';
                        display: block;
                        clear: both;
                    }
                /* ---- grid-item ---- */
                .grid-sizer,
                .grid-item {
                    width: 25%;
                }

                .grid-item {
                    display: flex;
                    justify-content: center;
                    height: 30%;
                    float: left;
                    color: var(--bs-light);
                    background: var(--bs-dark);
                    border: 3px solid #333;
                    border-color: var(--bs-light);
                    border-radius: 50px;
                }

                    .grid-item h1 {
                        font-family: 'MyBlackford' !important;
                    }

                        .grid-item h1 span {
                            font-family: 'MyBlackford' !important;
                        }

                .grid-item--width2 {
                    width: 50%;
                }

                .grid-item--width3 {
                    width: 75%;
                }

                .grid-item--width4 {
                    width: 100%;
                }

                .grid-item--height2 {
                    height: 60%;
                }

                .grid-item--height3 {
                    height: 90%;
                }

                @media (max-width: 767px) {
                    .grid-item {
                        width: 50%;
                        height: 18%;
                    }

                        .grid-item img {
                            height: 60px;
                            width: 60px;
                        }

                    .grid-item--width2 {
                        width: 50%;
                    }

                        .grid-item--width2 .display-2 {
                            font-size: calc(1.425rem + 2.1vw);
                            font-weight: 300;
                            line-height: 1.2;
                        }

                    .grid-item--width3 {
                        width: 100%;
                    }

                        .grid-item--width3 .display-2 {
                            font-size: calc(1.425rem + 2.1vw);
                            font-weight: 300;
                            line-height: 1.2;
                        }

                    .grid-item--width4 {
                        width: 100%;
                    }

                    .grid-item--height2 {
                        height: 36%;
                    }

                    .grid-item--height3 {
                        height: 54%;
                    }
                }

                #messagesList > li > button {
                    background-color: var(--bs-light);
                    color: var(--bs-dark);
                    border-radius: 30px 30px 0px 30px;
                    max-width: 65%;
                    border-style: none;
                    cursor: default;
                }

                    #messagesList > li > button.other {
                        border-radius: 30px 30px 30px 0px;
                    }

                input[type='file'] {
                    display: none;
                }
            </style>
        </head>
        <body class='d-flex'>
            <div class='mx-auto parallax text-center h-100 pt-5' style='max-width: 500px;'>
                <div class='card p-sm-2 dark m-auto mt-3'>
                    <div class='card-body'>
                        <h1 class='card-title text-center mb-0 mt-1'>Account confirmation</h1>
                        Here is the confirmation link for your email: " + url + @"
                    </div>
                </div>
            </div>
        </body>
        </html>";
    }

    public static string ConfirmEmail(string url)
    {
        return "Welcome,\n" +
               "Here is the confirmation link for your email: " +
               url + ".\n";
    }

    public static readonly string RetrievePassword = @"<html lang='en'>
                <head>
                    <meta charset='utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                    <meta name='google' content='notranslate' />
                    <meta name='author' content='Artisashop' />

                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@@5.0.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1' crossorigin='anonymous' />
                </head>
                <body>
                    <div class='mx-auto parallax text-center h-100 pt-5' style='max-width: 500px;'>
                        <div class='card p-sm-2 dark m-auto mt-3'>
                            <div class='card-body'>
                                <h1 class='card-title text-center mb-0 mt-1'>Password Recovery</h1>
                                Here is a new password for your account :\n" + _utils.RandomCode(10) + @"
                            </div>
                        </div>
                    </div>
                </body>
                </html>";

    public static string CertificateWaitingValidationCraftsman()
    {
        return @"<html lang='en'>
                <head>
                    <meta charset='utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                    <meta name='google' content='notranslate' />
                    <meta name='author' content='Artisashop' />

                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@@5.0.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1' crossorigin='anonymous' />
                </head>
                <body>
                    <div class='mx-auto parallax text-center h-100 pt-5' style='max-width: 500px;'>
                        <div class='card p-sm-2 dark m-auto mt-3'>
                            <div class='card-body'>
                                <h1 class='card-title text-center mb-0 mt-1'>Account Validation</h1>
                                Your account is waiting a certificate validation
                            </div>
                        </div>
                    </div>
                </body>
            </html>";
    }

    public static string CertificateWaitingValidationAdmin(string username)
    {
        return @"<html lang='en'>
                <head>
                    <meta charset='utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                    <meta name='google' content='notranslate' />
                    <meta name='author' content='Artisashop' />

                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@@5.0.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1' crossorigin='anonymous' />
                </head>
                <body>
                    <div class='mx-auto parallax text-center h-100 pt-5' style='max-width: 500px;'>
                        <div class='card p-sm-2 dark m-auto mt-3'>
                            <div class='card-body'>
                                <h1 class='card-title text-center mb-0 mt-1'>Account Validation</h1>
                                " + username + @" is waiting a certificate validation
                            </div>
                        </div>
                    </div>
                </body>
            </html>";
    }

    public static string CertificateValidatedCraftsman()
    {
        return @"<html lang='en'>
                <head>
                    <meta charset='utf-8' />
                    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                    <meta name='google' content='notranslate' />
                    <meta name='author' content='Artisashop' />

                    <link href='https://cdn.jsdelivr.net/npm/bootstrap@@5.0.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet' integrity='sha384-giJF6kkoqNQ00vy+HMDP7azOuL0xtbfIcaT9wjKHr8RbDVddVHyTfAAsrekwKmP1' crossorigin='anonymous' />
                </head>
                <body>
                    <div class='mx-auto parallax text-center h-100 pt-5' style='max-width: 500px;'>
                        <div class='card p-sm-2 dark m-auto mt-3'>
                            <div class='card-body'>
                                <h1 class='card-title text-center mb-0 mt-1'>Account Validation</h1>
                                Your certificate has been validated
                            </div>
                        </div>
                    </div>
                </body>
            </html>";
    }

    public static string ItemSold(Account buyer, List<Basket> basket)
    {
        string rtn = "Buyer name: " + buyer.Firstname + " " + buyer.Lastname + "\r\n";
        foreach (Basket item in basket)
            rtn += "\t- " + item.Product!.Name + " * " + item.Quantity + " - " +
                   (DeliveryOption.DELIVERY == item.DeliveryOpt ? "delivery" : "take out") + "\r\n";
        return rtn;
    }

    public static string ItemBought(List<Bill> bills)
    {
        string rtn = "Your basket: \r\n";
        double tot = 0;
        foreach (Bill bill in bills)
        {
            rtn += "\t- " + bill.ProductName + " * " + bill.Quantity + " - " + bill.CraftsmanName + " - " +
                   bill.PriceTot + "\r\n";
            tot += bill.PriceTot;
        }

        rtn += "Total: " + tot;
        return rtn;
    }
}