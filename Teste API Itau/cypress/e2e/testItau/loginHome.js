class LoginHomePage{



    elements = {
        campoEmail : () => cy.get('campoEmail'),
        campoSenha : () => cy.get('campoSenha')
    }

    visit() {
        cy.visit('INSERIR URL DE LOGIN AQUI');
    }

    realizarLogin() {
        this.elements.campoEmail().type('exemplo@exemplo.com.br');
        this.elements.campoSenha().type('senhasupersegura123');
        this.elements.botaoLogin().click();
    }

}

