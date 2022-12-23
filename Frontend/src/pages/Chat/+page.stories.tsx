// Button.stories.ts|tsx

import React from 'react';

// eslint-disable-next-line import/no-extraneous-dependencies
import { ComponentStory, ComponentMeta } from '@storybook/react';

const ChatPage = () => <div>ChatPage</div>;

export default {
  /* 👇 The title prop is optional.
  * See https://storybook.js.org/docs/react/configure/overview#configure-story-loading
  * to learn how to generate automatic titles
  */
  title: 'Pages/Chat',
  component: ChatPage,
} as ComponentMeta<typeof ChatPage>;

// 👇 We create a “template” of how args map to rendering
const Template: ComponentStory<typeof ChatPage> = (args) => <ChatPage />;

export const Index = Template.bind({});
Index.args = {
};
