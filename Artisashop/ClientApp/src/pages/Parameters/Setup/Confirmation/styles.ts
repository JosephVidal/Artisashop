import styled from "styled-components";

export const Wrapper = styled.div`
  height: 560px;
  width: 60%;

  .p-scrollpanel.p-component {
    height: inherit;

    .p-scrollpanel-content {
      height: 100%;
      overflow-x: hidden;
      z-index: 0;
      display: flex;
      flex-direction: column;
      align-items: center;
    }

    .p-scrollpanel-bar-x {
      visibility: hidden;
    }

    .p-scrollpanel-bar-y {
      visibility: visible;
    }
  }
`;

interface ConfirmationTitleProps {
  marginTop?: boolean;
}

export const ConfirmationTitle = styled.div<ConfirmationTitleProps>`
  text-align: center;
  font-size: 20px;
  margin-bottom: 25px;
  margin-top: ${(props) => (props.marginTop ? "50px" : 0)};
`;

export const InlineTextWrapper = styled.div`
  display: flex;
  flex-direction: row;
  align-items: center;
  width: 100%;
  margin-bottom: 18px;
`;

export const InlineTextLeft = styled.div`
  margin-right: 40px;
  text-align: end;
  font-size: 18px;
  font-weight: 300;
  flex: 0.5;
`;

export const InlineTextRight = styled.div`
  margin: 0 10px 0 0;
  text-align: start;
  font-size: 18px;
  font-weight: normal;
  flex: 0.5;
`;

export const TextNormal = styled.span`
  font-weight: normal;
`;

export const TextLight = styled.span`
  font-weight: 300;
`;
