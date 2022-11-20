import React, { useState, useEffect } from "react";
import Loader from "components/Loader";
import { ContentLoaderWrapper } from "./styles";

interface Props {
  autoExpireDelay?: number;
  loading?: boolean;
  children: React.ReactNode;
}

const ContentLoader: React.FunctionComponent<Props> = (props: Props) => {
  const [loading, setLoading] = useState<boolean>(
    props.autoExpireDelay ? true : props.loading || false
  );
  const [hasBeenInitialized, setHasBeenInitialized] = useState<boolean>(false);

  if (props.loading !== loading) {
    if (hasBeenInitialized) setLoading(props.loading || false);
    else setHasBeenInitialized(true);
  }

  useEffect(() => {
    if (props.autoExpireDelay) {
      setTimeout(() => setLoading(false), props.autoExpireDelay);
    }
  });

  return (
    <ContentLoaderWrapper>
      {loading ? <Loader visible={loading} /> : props.children}
    </ContentLoaderWrapper>
  );
};

ContentLoader.defaultProps = {
  autoExpireDelay: undefined,
  loading: false,
};

export default ContentLoader;
