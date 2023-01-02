import styled from "styled-components";

export const SearchHeader = styled.div`
    display: flex;
    padding: 15px;
    flex-direction: row;
    justify-content: space-between;
    background-color: #2F3B4B;

    span {
        display: flex;
        flex: 1 1 auto;
        text-align: center;
        align-items: center;
        margin: 5px;
    }

    a {
        text-decoration: none;
        margin-left: 15px;
    }

    ul {padding: 0;}

    label {margin: auto 0;}

    #search-bar {
        display: flex;
        flex-direction: row;
        margin-right: 4%;
    }

    #suggest {
        display: flex;
    }

    @media (max-width: 930px) {
        justify-content: center;

        #suggest {display: none}
    }
`;

export const SearchFilters = styled.aside`
    display: none;
    position: sticky;
    max-height: 20vh;
    bottom: 10vh;
    color: var(--bs-dark);
    width: 15vw;
    padding: 20px;

    .filter {
        margin-right: 20px;

        &:not(:last-child) {padding-bottom: 20px;}

        ul {padding: 0;}

        li {list-style: none;}

        input {
            margin-right: 7px;

            &:checked {background-color: red;}
        }

        .star {
            visibility: hidden;
            font-size: 20px;
            cursor: pointer;
            color: #452A16;
        }

        .star:checked:before {content: "\2605";}

        .star:before {
            content: "\2606";
            visibility: visible;
        }

        .quantity {
            color: #aaa;
            padding-left: 5px;
        }

        h2 {
            font-size: 20px;
            font-weight: bold;
        }
    }
`;

export const Wrapper = styled.div`
    color: var(--artshp-dark-blue);

    .search {
        padding-top: 56px;

        form {padding: 10px;}
    }

    #search-form {
        display: flex;
        flex-direction: row;
        height: 50px;
    }

    #search-body {
        display: flex;
        margin: 30px;
    }

    #search-button {
        border: 0;
        color: var(--bs-light);
        border-radius: var(--elem-radius);
        background-color: var(--bs-secondary);
        transition: 0.3s;

        &:hover {
            background-color: var(--bs-light);
            color: var(--bs-dark);
        }
    }

    input[type=range]::-webkit-slider-runnable-track {
        -webkit-appearance: none;
        width: 300px;
        height: 1rem;
        background: var(--bs-secondary);
        cursor: ew-resize;
        border-radius: 1.5rem;
    }

    .choice {
        color: var(--bs-white);
        list-style: none;
    }

    .product, .suggestion, .craftsman {
        display: block;
        margin: 40px;
        color: var(--bs-dark);

        &:hover {color: var(--bs-secondary);}

        img {
            display: block;
            object-fit: cover;
            width: 300px;
            height: 300px;
            border-radius: calc(var(--elem-radius)/2);
            margin-bottom: 5px;
        }

        h3 {
            display: inline;
            font-size: 20px;
            margin-right: 15px;
        }

        .tag {
            font-size: 15px;
            color: var(--bs-white);
            background-color: #452A16;
            border-radius: var(--elem-radius);
            padding: 3px 6px;
        }

        p {
            font-size: 20px;
            font-weight: bold;
        }
    }


    #search-result-block {
        padding: 20px;
        border-left: solid 2px var(--bs-dark);
        margin-left: 30px;
    }

    #result-list {
        display: flex;
        flex-wrap: wrap;
        justify-content: space-around;
        align-items: flex-start;
        width: 80vw;

        h2 {font-weight: lighter;}
    }

    #resultList {
        a {
            color: black;
            text-decoration: none;

            &:hover {
                color: #C8C8C8;
                text-decoration: none;
                transition: all .2s ease-out;
            }
        }
    }

    #suggestions {
        margin: 70px;
        padding: 20px;
        border-top: solid var(--bs-dark) 2px;

        #suggestions-wrapper {
            display: flex;
            justify-content: space-around;

            a {
                color: var(--bs-dark);

                &:hover {color: var(--bs-secondary);}
            }
        }
    }
`;