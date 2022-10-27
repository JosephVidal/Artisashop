import styled from "styled-components";

interface SelectWrapperProps {
  visible: boolean;
}

export const SelectWrapper = styled.div<SelectWrapperProps>`
  width: 100%;
  display: ${(props) => (props.visible ? "inline-block" : "none")};

  & .p-dropdown {
    display: flex;
  }
`;
