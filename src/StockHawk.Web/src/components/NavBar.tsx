import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import MenuIcon from '@mui/icons-material/Menu';
import Container from '@mui/material/Container';
import MenuItem from '@mui/material/MenuItem';
import { SignInSignOutButton } from "./SignInButton";
import { Link } from 'react-router-dom';
import { AuthenticatedTemplate } from '@azure/msal-react';
import { Divider } from '@mui/material';

const pages = ['Products', 'Customers', 'Orders', 'Stock'];

export const NavBar = () => {
    const [anchorElNav, setAnchorElNav] = React.useState<null | HTMLElement>(null);

    const handleOpenNavMenu = (event: React.MouseEvent<HTMLElement>) => {
        setAnchorElNav(event.currentTarget);
    };

    const handleCloseNavMenu = () => {
        setAnchorElNav(null);
    };

    return (
        <AppBar position="static">
            <Container maxWidth={false}>
                <Toolbar disableGutters>
                    <Link to="/"
                        className="h6 mr-2 hidden md:flex font-mono font-bold tracking-widest text-inherit no-underline text-nowrap"
                    >
                        StockHawk
                    </Link>
                    <Box sx={{ flexGrow: 1, display: { xs: 'flex', md: 'none' } }}>
                        <IconButton
                            size="large"
                            aria-label="account of current user"
                            aria-controls="menu-appbar"
                            aria-haspopup="true"
                            onClick={handleOpenNavMenu}
                            color="inherit"
                        >
                            <MenuIcon />
                        </IconButton>
                        <Menu
                            id="menu-appbar"
                            anchorEl={anchorElNav}
                            anchorOrigin={{
                                vertical: 'bottom',
                                horizontal: 'left',
                            }}
                            keepMounted
                            transformOrigin={{
                                vertical: 'top',
                                horizontal: 'left',
                            }}
                            open={Boolean(anchorElNav)}
                            onClose={handleCloseNavMenu}
                            sx={{
                                display: { xs: 'block', md: 'none' },
                            }}
                        >
                            <AuthenticatedTemplate>
                                {pages.map((page) => (
                                    <MenuItem key={page} onClick={handleCloseNavMenu}>
                                        <Link
                                            key={page}
                                            onClick={handleCloseNavMenu}
                                            className={"m-2 block text-inherit"}
                                            to={"/" + page}>
                                            {page}
                                        </Link>
                                    </MenuItem>
                                ))}
                            </AuthenticatedTemplate>
                            <Divider />
                            <SignInSignOutButton />
                        </Menu>
                    </Box>
                    <Link
                        to="/"
                        className="mr-2 flex md:hidden flex-grow font-mono font-bold tracking-widest text-inherit no-underline"
                    >
                        StockHawk
                    </Link>

                    <Box sx={{ flexGrow: 1, display: { xs: 'none', md: 'flex' } }}>
                        <AuthenticatedTemplate>
                            {pages.map((page) => (
                                <Link
                                    key={page}
                                    onClick={handleCloseNavMenu}
                                    className={"m-2 block"}
                                    to={"/" + page}>
                                    {page}
                                </Link>
                            ))}
                        </AuthenticatedTemplate>
                        <Divider orientation="vertical" flexItem />
                        <SignInSignOutButton />
                    </Box>
                </Toolbar>
            </Container>
        </AppBar >
    );
}
// REf: https://mui.com/material-ui/react-app-bar/#system-MenuAppBar.tsx