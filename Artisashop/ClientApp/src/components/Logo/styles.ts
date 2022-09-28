import styled from "styled-components";

export const LogoWrapper = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
`;

interface LogoImgProps {
  withText: boolean;
}

export const LogoImg = styled.img<LogoImgProps>`
  width: ${(props) => (props.withText ? "50%" : "100%")};
`;

export const TextImg = styled.img`
  width: 100%;
  margin-top: 12%;
`;
