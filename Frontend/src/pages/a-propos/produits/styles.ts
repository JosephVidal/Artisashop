import styled from "styled-components";

export const Wrapper = styled.div`
    font-family: Helvetica;
    color: var(--artshp-white);

    .text-part {
        margin: auto 0;

        h1 {
            font-size: 3em;
            margin-bottom: 100px;
            font-weight: light;
        }

        p {
            width: 50vw;
            font-size: 1.5em;
            font-weight: lighter;
        }
    }
`;

export const DescSection = styled.section`
    display: flex;
    flex-direction: row;
    height: 100vh;
    background-color: var(--artshp-dark-blue);
    padding: 80px 50px;

    img {
        object-fit: cover;
        border-radius: 50%;
    }

    #img-part {
        display: flex;
        flex-direction: column;
        margin: auto;

        #img-solo {
            height: 400px;
            width: 400px;
            margin-left: 180px;
            margin-top: 55px;
        }

        #img-group {
            img {
                :nth-child(1) {
                    height: 240px;
                    width: 240px;
                    margin-top: 20px;
                }

                :nth-child(2) {
                    height: 350px;
                    width: 350px;
                    margin-bottom: 40px;
                    margin-left: 30px;
                }
            }
        }
    }

    @media (max-width: 590px) {
        #img-solo {
            height: 200px;
            width: 200px;
            margin-left: 80px;
            margin-top: 15px;
        }

        #img-group {
            img {
                :nth-child(1) {
                    height: 70px;
                    width: 70px;
                    margin-top: 20px;
                }

                :nth-child(2) {
                    height: 120px;
                    width: 120px;
                    margin-bottom: 40px;
                    margin-left: 30px;
                }
            }
        }
    }
`;

export const WhySection = styled.section`
    display: flex;
    padding: 80px 50px;
    height: 100vh;
    background-image: url("/img/about-product.png");
    background-color: var(--artshp-dark-blue);
    background-size: cover;
    background-attachment: fixed;
`;