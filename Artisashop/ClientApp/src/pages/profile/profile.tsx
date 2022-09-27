import {
    Box,
    Button,
    Heading,
    Text,
    useColorModeValue,
    useEditableControls,
    VStack,
    Input,
    ButtonGroup, Flex, Editable, EditablePreview, EditableInput, HStack, Divider, SimpleGrid,
} from "@chakra-ui/react";
import {useAuth} from "../../hooks/useAuth";
import {CheckIcon, CloseIcon, EditIcon} from "@chakra-ui/icons";
import {
    Camera, 
    Facebook as FacebookIcon, 
    FilePersonFill,
    Google as GoogleIcon,
    Twitter as TwitterIcon,

} from "react-bootstrap-icons";

const EditableField = () => {
    const {} = useEditableControls()
}

export default function ProfilePage() {
    const auth = useAuth()

    const cardBg = useColorModeValue('gray.200', 'gray.700')

    function EditableControls() {
        const {
            isEditing,
            getSubmitButtonProps,
            getCancelButtonProps,
            getEditButtonProps,
        } = useEditableControls()

        return isEditing ? (
            <ButtonGroup justifyContent='center' size='sm'>
                <Button {...getSubmitButtonProps()}>
                    <CheckIcon/>
                </Button>
                <Button {...getCancelButtonProps()}>
                    <CloseIcon/>
                </Button>
            </ButtonGroup>
        ) : (
            <Flex justifyContent='center'>
                <Button size='sm' {...getEditButtonProps()}>
                    <EditIcon/>
                </Button>
            </Flex>
        )
    }

    return (
        <Box>
            <Heading>Votre profil</Heading>
            <VStack bg={cardBg} rounded={10} mt={5} pt={3} pb={6} px={6} spacing={3} align="left">
                <Box>
                    <Text as="h3" fontSize="2xl">Vos Infos</Text>
                    <SimpleGrid columns={2} w="50%" spacing={2} mt={3}>
                        <Text as="h4" fontSize="xl">Nom et Prénom</Text>
                        <Editable defaultValue={auth?.user?.username ?? ''} textAlign="left" fontSize='xl'
                                  isPreviewFocusable={false}>
                            <HStack justifyContent="start">
                                <EditablePreview/>
                                <Input as={EditableInput}/>
                                <EditableControls/>
                            </HStack>
                        </Editable>
                        <Text as="h4" fontSize="xl">Nom d'utilisateur</Text>
                        <Editable defaultValue={auth?.user?.username ?? ''} textAlign="left" fontSize='xl'
                                  isPreviewFocusable={false}>
                            <HStack justifyContent="start">
                                <EditablePreview/>
                                <Input as={EditableInput}/>
                                <EditableControls/>
                            </HStack>
                        </Editable>
                        <Text as="h4" fontSize="xl">Email</Text>
                        <Box>
                            <Editable defaultValue={auth?.user?.email ?? ''} textAlign="left" fontSize='xl'
                                      isPreviewFocusable={false}>
                                <HStack justifyContent="start">
                                    <EditablePreview/>
                                    <Input as={EditableInput}/>
                                    <EditableControls/>
                                </HStack>
                            </Editable>
                        </Box>
                        <Text fontSize="xl">Vérification d'email</Text>
                        <Box>
                            {auth?.user?.emailConfirmed == false
                                ?
                                <Button colorScheme="red" variant="link" textDecoration="underline">
                                    renvoyer un email de confirmation
                                </Button>
                                :
                                <Text>Votre email est bien vérifié !</Text>
                            }
                        </Box>
                    </SimpleGrid>
                </Box>
                <Divider/>
                <Box>
                    <Text as="h3" fontSize="2xl">Comptes tiers</Text>
                    <VStack align="left" mt={3}>
                        <Box>
                            <Button leftIcon={<FacebookIcon/>}>Associer Facebook</Button>
                        </Box>
                        <Box>
                            <Button leftIcon={<GoogleIcon/>}>Associer Google</Button>
                        </Box>
                        <Box>
                            <Button leftIcon={<TwitterIcon/>}>Associer Twitter</Button>
                        </Box>
                    </VStack>
                </Box>
                <Divider/>
                <VStack align="start">
                    <Text as="h3" fontSize="2xl">
                        Vérifiez votre identité (artisans)
                    </Text>
                    <Text>
                        En tant qu'artisan certifié, vous devez fournir une preuve de votre identité.
                        Cette preuve peut être fournie via votre compte FranceConnect, ou en envoyant une photo
                        recto/verso de votre carte d'identité.
                    </Text>
                    <HStack spacing={5}>
                        <Button fontSize="xl" leftIcon={<FilePersonFill/>}>
                            <Text>Se connecter avec FranceConnect</Text>
                        </Button>
                        <Text>Ou</Text>
                        <Button fontSize="xl" leftIcon={<Camera />}>
                            Téléchargez votre carte d'identité
                        </Button>
                    </HStack>
                </VStack>
            </VStack>
        </Box>
    )
}