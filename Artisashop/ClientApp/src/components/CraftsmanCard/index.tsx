import React from "react";
import { CraftsmanCardWrapper } from "./styles";

interface Props {
    name: string;
    job: string;
    img: string;
    description: string;
}

const CraftsmanCard: React.FunctionComponent<Props> = ({
    name,
    job,
    img,
    description,
}) => (
  <CraftsmanCardWrapper>
    <div id="card">
        <div id="card-header">
            <img src={img} alt="" />
            <div>
                <p id="craftsman-name">{name}</p>
                <p id="craftsman-job">{job}</p>
            </div>
        </div>
        <p>{description}</p>
    </div>
  </CraftsmanCardWrapper>
);

export default CraftsmanCard;
