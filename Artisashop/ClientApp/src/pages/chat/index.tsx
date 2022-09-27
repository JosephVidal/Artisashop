import {
    Avatar,
    Box,
    Button,
    Container,
    Heading,
    HStack,
    Icon,
    IconButton,
    Input,
    LightMode,
    Text,
    Textarea,
    useColorModeValue,
    VStack
} from "@chakra-ui/react";
import {ArrowForwardIcon} from '@chakra-ui/icons';
import {useParams} from "react-router-dom";

export default function Chat() {
    const {userId} = useParams();
    const bgColor = useColorModeValue('blackAlpha.100', 'whiteAlpha.100')
    const blueBubble = useColorModeValue('blue.500', 'blue.500')
    const grayBubble = useColorModeValue('gray.300', 'gray.300')
    return (
        <Box>
            <Heading>Chatter avec <b>{userId}</b></Heading>
            <Box bg={bgColor} p={5} rounded={5} mt={3}>
                <VStack align="stretch">
                    {[
                        {isMe: false, text: 'Hello'},
                        {isMe: false, text: 'How are you ?'},
                        {isMe: true, text: 'Hello ! I\'m fine thanks !\n Is the product still available ?'},
                    ].map(({isMe, text}) => (
                        <HStack w="full" justify={isMe ? "end" : "start"} align="start">
                            <VStack align={isMe ? "end" : "start"} spacing={1}>
                                <Box
                                    bg={isMe ? blueBubble : grayBubble}
                                    p={2}
                                    rounded={10}
                                    roundedTopRight={isMe ? 0 : 10}
                                    roundedTopLeft={isMe ? 10 : 0}
                                    color={isMe ? "white" : "black"}
                                >
                                    {text.split('\n').map(line => (
                                        <span key={line}>
                        <span>{line}</span>
                        <br/>
                      </span>
                                    ))}
                                </Box>
                                <Text color="gray">10:23</Text>
                            </VStack>
                        </HStack>
                    ))}
                </VStack>
                <HStack justify="stretch" mt={3} align="start">
                    <Input
                        size="lg"
                        variant="solid"
                        placeholder="Rédigez un message..."
                        resize="none"
                    />
                    <LightMode>
                        <IconButton size="lg" colorScheme="blue" icon={<ArrowForwardIcon/>}
                                    aria-label="Envoyer votre message"/>
                    </LightMode>
                </HStack>
            </Box>
        </Box>
    )
}