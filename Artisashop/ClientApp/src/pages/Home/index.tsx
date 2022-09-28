import React from "react";
import Input from "components/Input";
import { Wrapper } from "./styles";

interface Props {}

const Home: React.FunctionComponent<Props> = () => (
  <Wrapper>
    <br />
    <br />

    <Input id="TestInput" type="text" label="Test input" />

    <br />
    <br />

    <Input type="number" label="Age" />
  </Wrapper>
);

export default Home;
