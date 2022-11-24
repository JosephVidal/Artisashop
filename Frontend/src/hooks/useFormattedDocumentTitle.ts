import useDocumentTitle from "./useDocumentTitle";

/**
 * Sets and formats the document title to the given title, example "TITLE - Artisashop".
 */
export default function useFormattedDocumentTitle(title: string, prevailOnUnmount = false) {
  useDocumentTitle(`${title} - Artisashop`, prevailOnUnmount);
}
